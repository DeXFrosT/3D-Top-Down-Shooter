using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public float damage;
    public float maxHealth;
    [HideInInspector] public float currentHealth;
    [SerializeField] private Collider bulletPrefab;

    public int points;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider bulletPrefab)
    {
        TakeDamage();

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
            ScoreCount.instance.currentScore += points;
        }
    }

    public void TakeDamage()
    {
        currentHealth -= damage;
    }
}
