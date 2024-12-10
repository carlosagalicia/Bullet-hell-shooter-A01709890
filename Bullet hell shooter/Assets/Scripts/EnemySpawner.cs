using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = .2f;
    public float spawnDistance = 50f;
    public float moveSpeed = 10f;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnEnemy()
    {

        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnDistance, spawnDistance),
            0f,
            Random.Range(-spawnDistance, spawnDistance)
        );


        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);


        Vector3 moveDirection = -spawnPosition.normalized;

 
        Rigidbody rb = enemy.GetComponent<Rigidbody>();
        rb.velocity = moveDirection * moveSpeed;


        if (rb != null)
        {

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            enemy.transform.rotation = Quaternion.Euler(targetRotation.eulerAngles.x, targetRotation.eulerAngles.y + 90f, targetRotation.eulerAngles.z);
        }
    }
}
