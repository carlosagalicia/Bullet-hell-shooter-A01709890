using UnityEngine;

public class BossEvent : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject bossHpText;


    void Start()
    {

        if (bossPrefab != null && bossHpText != null)
        {
            bossPrefab.SetActive(false);
            bossHpText.SetActive(false);
        }
    }

    void Update()
    {
        TimeCheck();
    }

    private void TimeCheck()
    {

        if (TimeManager.Hour == 0 && TimeManager.Minute == 20)
        {
            if (bossPrefab != null && bossHpText != null)
            {
                bossPrefab.SetActive(true);
                bossHpText.SetActive(true);
            }
        }
    }

}
