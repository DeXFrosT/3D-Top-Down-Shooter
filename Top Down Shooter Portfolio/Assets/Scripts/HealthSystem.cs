using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float health;
    private float healValue = 10f;
    public float maxHealth;
    public float damageValue;

    public Slider slider;

    public GameObject healthBarUI;
    public GameObject pauseMenuUI;
    public GameObject gameOverTextUI;
    public GameObject resumeButtonUI;

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
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
            resumeButtonUI.SetActive(false);
            gameOverTextUI.SetActive(true);
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
