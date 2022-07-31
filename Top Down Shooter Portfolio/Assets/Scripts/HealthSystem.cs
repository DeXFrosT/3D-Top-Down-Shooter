using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float health;
    public float maxHealth;
    public float damageValue;
    private float healValue = 10f;

    public GameObject healthBarUI;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if (health <= 0)
        {
            Debug.Log("Game Over!");
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }       
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        } else

        if(collider.gameObject.CompareTag("Health"))
        {
            Heal();
            Destroy(collider.gameObject);
        }
    }

    public void TakeDamage()
    {
        health -= damageValue;
    }

    public void Heal()
    {
        health += healValue;
    }
}
