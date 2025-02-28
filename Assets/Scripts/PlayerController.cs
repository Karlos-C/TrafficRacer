using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float upCollision = 100;
    AudioSource audioSource;
    [SerializeField] AudioClip sfxCrash;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * x * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * upCollision);

            GameObject.Find("Road").GetComponent<Scrolling>().enabled = false;
            GameObject.Find("Grass").GetComponent<Scrolling>().enabled = false;

            //Destroy(GameObject.GetComponent<PlayerController>());

            Rotation[] rot = GetComponentsInChildren<Rotation>();

            foreach (Rotation item in rot)
            {
                item.enabled = false;
            }

            GameObject.Find("Spawn").GetComponent<Spawn>().StopSpawn();

            transform.Find("ParticleSmoke").GetComponent<ParticleSystem>().Play();

            audioSource.Stop();
            audioSource.PlayOneShot(sfxCrash);

            GameObject.Find("Music").GetComponent<AudioSource>().enabled = false;
            Destroy(GameObject.Find("Music"));

            GetComponent<GameOver>().ShowGameOver();
        }
    }
}