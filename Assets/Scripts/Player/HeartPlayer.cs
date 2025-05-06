using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartPlayer : MonoBehaviour
{
    public string sceneToLoad;
    public int Health = 3;
    public int currentHealth;

    private HealthDisplay healthDisplay;
    void Start()
    {
        currentHealth = Health;

        // ค้นหา HealthDisplay ที่อยู่ใน scene
        healthDisplay = Object.FindAnyObjectByType<HealthDisplay>();
        if (healthDisplay != null)
        {
            healthDisplay.maxHealth = Health;
            healthDisplay.health = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, Health);

        if (healthDisplay != null)
        {
            healthDisplay.health = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, Health);

        if (healthDisplay != null)
        {
            healthDisplay.health = currentHealth;
        }
    }

    private void Die()
    {
    
        Destroy(gameObject);
        SceneManager.LoadScene(sceneToLoad);
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        TakeDamage(1);

        if (Input.GetKeyDown(KeyCode.Equals))  // ปุ่ม '=' คือคีย์ข้างๆ '-' บนคีย์บอร์ด
        Heal(1);
    }
}
