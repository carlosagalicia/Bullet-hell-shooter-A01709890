using UnityEngine;
using UnityEngine.UI;


public class GameOverScreen : MonoBehaviour
{
    public Text resultText;


    public Health playerHealth;
    public Health bossHealth;

    public void Setup()
    {
        gameObject.SetActive(true);

        if (playerHealth.currentHealth <= 0)
        {
            resultText.text = "you lost...";
        }

        else if (bossHealth.currentHealth <= 0)
        {
            resultText.text = "you won!";
        }

        Time.timeScale = 0f;
    }

}
