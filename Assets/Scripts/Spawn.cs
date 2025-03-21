using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] Transform[] sp;
    [SerializeField] float spawnRate = 1.5f;
    [SerializeField] ParticleSystem spawnEffect;
    [SerializeField] AudioClip spawnSound;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject[] obstacles;
    [SerializeField] GameObject[] powerUps;
    [SerializeField] Light sceneLight;

    int totalCars = 0;

    void Start()
    {
        StartCoroutine(SpawnCar());
        StartCoroutine(IntenseSpawn());
    }

    IEnumerator SpawnCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            totalCars++;

            spawnRate *= 0.95f;
            spawnRate = Mathf.Clamp(spawnRate, 0.3f, 1.5f);

            int nr = Random.Range(0, cars.Length);
            int x = Random.Range(0, sp.Length);

            GameObject carInstance = Instantiate(cars[nr], sp[x].position, Quaternion.identity);
            float speedMultiplier = Random.Range(0.8f, 1.5f);
            carInstance.GetComponent<MoveForward>().speed *= speedMultiplier;

            if (spawnEffect != null)
                Instantiate(spawnEffect, sp[x].position, Quaternion.identity);

            if (audioSource != null && spawnSound != null)
                audioSource.PlayOneShot(spawnSound);

            if (Random.value < 0.2f)
                SpawnObstacle();

            if (Random.value < 0.1f)
                SpawnPowerUp();
        }
    }

    IEnumerator IntenseSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            for (int i = 0; i < 5; i++)
            {
                StartCoroutine(SpawnCar());
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

    void SpawnObstacle()
    {
        int pos = Random.Range(0, sp.Length);
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], sp[pos].position, Quaternion.identity);
    }

    void SpawnPowerUp()
    {
        int pos = Random.Range(0, sp.Length);
        Instantiate(powerUps[Random.Range(0, powerUps.Length)], sp[pos].position, Quaternion.identity);
    }

    void Update()
    {
        sceneLight.intensity = Mathf.PingPong(Time.time * 0.2f, 1.0f);
    }
}