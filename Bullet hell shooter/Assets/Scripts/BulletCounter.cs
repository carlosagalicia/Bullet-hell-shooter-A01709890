using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public TextMeshProUGUI bulletCountText;

    void Update()
    {

        int bulletCount = GameObject.FindGameObjectsWithTag("Bullet").Length + GameObject.FindGameObjectsWithTag("BulletBeam").Length;
        bulletCountText.text = "Balas en pantalla: \n " + bulletCount;
    }
}
