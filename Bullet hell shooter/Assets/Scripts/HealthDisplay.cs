using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{

    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI bossHealthText;

    public GameOverScreen gameOverScreen; 


    public Health playerHealth; 
    public Health bossHealth;   

    void Update()
    {
        playerHealthText.text = "Player Health: " + playerHealth.currentHealth;
        bossHealthText.text = "HP del jefe final: " + bossHealth.currentHealth;
        if (playerHealth.currentHealth == 0 || bossHealth.currentHealth == 0)
        {
            gameOverScreen.Setup();
        }
    }
}