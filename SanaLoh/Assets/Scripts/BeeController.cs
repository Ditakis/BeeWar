using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public Transform hive; // Ссылка на улей (куб).
    public float rotationSpeed = 30f; // Скорость вращения пчёл.
    public GameObject beePrefab; // Префаб пчелы.
    public int numberOfBees = 10; // Общее количество пчёл.
    public float spawnInterval = 2f; // Интервал между спаунами.
    public Transform spawnPoint; // Ссылка на точку спауна пчёл.
    public float minDistanceFromHive = 2f; // Минимальное расстояние от улья.
    public float maxDistanceFromHive = 5f; // Максимальное расстояние от улья.
    public BeeCounterText beeCounterText;





    private int beesSpawned = 0;
    private float spawnTimer = 0f;

    void Update()
    {
        // Спаун пчёл с интервалом.
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval && beesSpawned < numberOfBees)
        {
            SpawnBee();
            spawnTimer = 0f;
        }
    }
    void StopHiveRotation()
    {
        hive.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    void Start()
    {
        StopHiveRotation();
    }
    void SpawnBee()
    {
        

        Debug.Log("Пчела создана!");

        // Вычисляем случайное радиальное расстояние и угол для размещения пчелы.
        float distance = Random.Range(minDistanceFromHive, maxDistanceFromHive);
        float angle = Random.Range(0f, 360f);
        Vector3 spawnPosition = spawnPoint.position + Quaternion.Euler(0f, angle, 0f) * Vector3.forward * distance;

        GameObject newBee = Instantiate(beePrefab, spawnPosition, Quaternion.identity);
        Rigidbody beeRigidbody = newBee.GetComponent<Rigidbody>();
        beeRigidbody.useGravity = false;
        beeRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        beesSpawned++;

        if (beeCounterText != null)
        {
            beeCounterText.IncreaseBeeCount();
        }
    }

    
}
