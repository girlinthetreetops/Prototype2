using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public float spawnRangeX = 20f;
    public float spawnPosY = 0.3f;

    public float startDelay = 0f;
    public float spawnInterval = 10f;

    private void Start()
    {
        InvokeRepeating("spawnAnimal", startDelay, spawnInterval);
    }

    private void spawnAnimal()
    {
        //randomly generate a spawn location
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosY);

        //randomly select one of the animals in the animalPrefabs list
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        //instantiate it
        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
    }
}
