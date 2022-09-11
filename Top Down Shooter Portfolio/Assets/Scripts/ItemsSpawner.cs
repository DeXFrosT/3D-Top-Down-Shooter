using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] GameObject healthPotionPrefab;
    [SerializeField] GameObject boosterPotionPrefab;

    private int healthPotionCount;
    private int boosterPotionCount;

    private float startDelay = 10.0f;
    private float spawnDelay = 15.0f;

    void Update()
    {
        // Health Potion counter.
        healthPotionCount = GameObject.FindGameObjectsWithTag("Health").Length;

        if (healthPotionCount < 1)
        {
            InvokeRepeating("SpawnHealthPotion", startDelay, spawnDelay);
        }

        // Booster counter.
        boosterPotionCount = GameObject.FindGameObjectsWithTag("Booster").Length;

        if (boosterPotionCount < 1)
        {
            InvokeRepeating("SpawnBoosterPotion", startDelay, spawnDelay);
        }
    }

    // Spawn Health Position prefab at random position.
    void SpawnHealthPotion()  
    {        
            float spawnPosX = Random.Range(-5, 7);
            float spawnPosZ = Random.Range(-10, 10);

            Vector3 randomPos = new Vector3(spawnPosX, 0.1f, spawnPosZ);

            Instantiate(healthPotionPrefab, randomPos, Quaternion.identity);

            CancelInvoke("SpawnHealthPotion");     
    }

    // Spawn Booster Potion prefab at random position.
    void SpawnBoosterPotion()  
    {
            float spawnPosX = Random.Range(-6, 6);
            float spawnPosZ = Random.Range(-10, 10);

            Vector3 randomPos = new Vector3(spawnPosX, 0.1f, spawnPosZ);

            Instantiate(boosterPotionPrefab, randomPos, Quaternion.identity);

            CancelInvoke("SpawnBoosterPotion");      
    }
}