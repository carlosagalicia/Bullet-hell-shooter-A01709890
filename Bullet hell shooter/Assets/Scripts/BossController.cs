using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    public float patternDuration = 10f;
    public float bulletSpeed = 5f;

    private int currentPattern = 0;
    private float nextFireTime = 0f;
    private float spiralAngle = 0f;
    public float spawnRadius = 2.0f;

    void Start()
    {
        StartCoroutine(SwitchPatterns());
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            FirePattern();
        }
    }

    IEnumerator SwitchPatterns()
    {
        while (true)
        {
            yield return new WaitForSeconds(patternDuration);
            currentPattern = (currentPattern + 1) % 3;
        }
    }

    void FirePattern()
    {
        switch (currentPattern)
        {
            case 0:
                FireSpiralPattern();
                break;
            case 1:
                FireWavePattern();
                break;
            case 2:
                FireRadialBurstPattern();
                break;
        }
    }

    // Espiral
    void FireSpiralPattern()
    {
        int bulletsPerWave = 1;
        spiralAngle += 10f; 
        if (spiralAngle >= 360f) spiralAngle -= 360f;

        for (int i = 0; i < bulletsPerWave; i++)
        {
            Vector3 bulletDir = new Vector3(Mathf.Sin(spiralAngle * Mathf.Deg2Rad), 0f, Mathf.Cos(spiralAngle * Mathf.Deg2Rad)).normalized;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
            bullet.GetComponent<Rigidbody>().velocity = bulletDir * bulletSpeed;

            Vector3 bulletDir2 = new Vector3(Mathf.Sin(-spiralAngle * Mathf.Deg2Rad), 0f, Mathf.Cos(-spiralAngle * Mathf.Deg2Rad)).normalized;
            GameObject bullet2 = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
            bullet2.GetComponent<Rigidbody>().velocity = bulletDir2 * bulletSpeed;

            Vector3 bulletDir3 = new Vector3(-Mathf.Sin(-spiralAngle * Mathf.Deg2Rad), 0f, -Mathf.Cos(-spiralAngle * Mathf.Deg2Rad)).normalized;
            GameObject bullet3 = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
            bullet3.GetComponent<Rigidbody>().velocity = bulletDir3 * bulletSpeed;

            Vector3 bulletDir4 = new Vector3(-Mathf.Sin(spiralAngle * Mathf.Deg2Rad), 0f, -Mathf.Cos(spiralAngle * Mathf.Deg2Rad)).normalized;
            GameObject bullet4 = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
            bullet4.GetComponent<Rigidbody>().velocity = bulletDir4 * bulletSpeed;
        }
    }

    // Ondas
    void FireWavePattern()
    {
        int bulletsPerWave = 7;
        float waveSpread = 60f;
        float startAngle = waveSpread;
        float angleStep = waveSpread / (bulletsPerWave - 1);

        for (int i = 0; i < bulletsPerWave; i++)
        {
            float angle = startAngle + i * angleStep;
            Vector3 bulletDir = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0f, Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
            bullet.GetComponent<Rigidbody>().velocity = bulletDir * bulletSpeed;
        }
    }

    // Rafagas radiales
    void FireRadialBurstPattern()
    {
        int bulletsPerBurst = 30;
        float angleStep = 360f / bulletsPerBurst;

        for (int i = 0; i < bulletsPerBurst; i++)
        {
            float angle = i * angleStep;
            Vector3 bulletDir = new Vector3(
                Mathf.Sin(angle * Mathf.Deg2Rad), 0f, Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;

            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
            bullet.GetComponent<Rigidbody>().velocity = bulletDir * bulletSpeed;
        }
    }
}
