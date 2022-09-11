using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] spawnPoints;

    public float startDelay = 2.0f;
    public float spawnDelay = 1.0f;

    public int maxEnemy = 15;
    private int enemy;

    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
       
        if (enemy <= maxEnemy)
        {
            InvokeRepeating("SpawnEnemies", startDelay, spawnDelay);
        }
    }

    void SpawnEnemies()
    {

        GameObject randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Vector3 randomPos = new Vector3(randomSpawnPoint.transform.position.x, 0.1f, randomSpawnPoint.transform.position.z);

        GameObject selectedEnemyPrefab = enemyPrefab[Random.Range(0, enemyPrefab.Length)];

        Instantiate(selectedEnemyPrefab, randomPos, Quaternion.identity);

        CancelInvoke();
    }
}