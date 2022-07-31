using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] GameObject healthPotionPrefab;
    [SerializeField] GameObject boosterPotionPrefab;

    private int _healthPotionCount;
    private int _boosterPotionCount;

    private float startDelay = 10.0f;
    private float spawnDelay = 15.0f;

    void Update()
    {
        // Health Potion counter.
        _healthPotionCount = GameObject.FindGameObjectsWithTag("Health").Length;

        if (_healthPotionCount < 1)
        {
            InvokeRepeating("SpawnHealthPotion", startDelay, spawnDelay);
        }

        // Booster counter.
        _boosterPotionCount = GameObject.FindGameObjectsWithTag("Booster").Length;

        if (_boosterPotionCount < 1)
        {
            InvokeRepeating("SpawnBoosterPotion", startDelay, spawnDelay);
        }
    }

    // Spawn Health Position prefab at random position.
    void SpawnHealthPotion()  
    {        
            float _spawnPosX = Random.Range(-6, 6);
            float _spawnPosZ = Random.Range(-10, 10);

            Vector3 _randomPos = new Vector3(_spawnPosX, 0.1f, _spawnPosZ);

            Instantiate(healthPotionPrefab, _randomPos, Quaternion.identity);

            CancelInvoke("SpawnHealthPotion");     
    }

    // Spawn Booster Potion prefab at random position.
    void SpawnBoosterPotion()  
    {
            float _spawnPosX = Random.Range(-6, 6);
            float _spawnPosZ = Random.Range(-10, 10);

            Vector3 _randomPos = new Vector3(_spawnPosX, 0.1f, _spawnPosZ);

            Instantiate(boosterPotionPrefab, _randomPos, Quaternion.identity);

            CancelInvoke("SpawnBoosterPotion");      
    }
}