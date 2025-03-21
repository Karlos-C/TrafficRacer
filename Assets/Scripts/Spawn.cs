using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    GameObject carInstance = Instantiate(cars[nr], sp[x].position, Quaternion.identity);
    float speedMultiplier = Random.Range(0.8f, 1.5f);
    carInstance.GetComponent<MoveForward>().speed *= speedMultiplier;


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

            spawnRate *= 0.95f; 
            spawnRate = Mathf.Clamp(spawnRate, 0.3f, 1.5f); 

            int nr = Random.Range(0, cars.Length);
            int x = Random.Range(0, sp.Length);
            Instantiate(cars[nr], sp[x].position, Quaternion.identity);
        }
    }
}