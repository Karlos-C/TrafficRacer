using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] Transform[] sp;
    [SerializeField] float spawnRate = 1.5f;
    int totalCars = 0;


    void Start()
    {
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            totalCars++;

            if (totalCars % 5 == 0)
            {
                spawnRate -= 0.1f;
                spawnRate = Mathf.Clamp(spawnRate, 0.3f, 1.5f);
            }

            int nr = Random.Range(0, cars.Length);
            int x = Random.Range(0, 3);
            Instantiate(cars[nr], sp[x].transform.position, transform.rotation);
        }
    }

    public void StopSpawn()
    {
        StopAllCoroutines();

        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");

        foreach (GameObject item in cars)
        {
            item.GetComponent<MoveForward>().enabled = false;
        }
    }
}