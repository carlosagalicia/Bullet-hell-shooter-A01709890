using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 1; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {

            health--;

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
