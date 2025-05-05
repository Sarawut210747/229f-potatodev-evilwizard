using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public UnityEngine.UI.Image[] hearts;
    public HeartPlayer heartPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = heartPlayer.currentHealth;
        maxHealth =  heartPlayer.Health;
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
