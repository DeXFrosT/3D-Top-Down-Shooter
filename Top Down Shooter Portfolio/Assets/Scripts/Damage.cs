using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private Collider bulletPrefab;
    [HideInInspector] public float currentHealth;

    public float damage;
    public float maxHealth;

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
