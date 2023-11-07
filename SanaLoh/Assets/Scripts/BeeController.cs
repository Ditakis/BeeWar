using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public Transform hive; // ������ �� ���� (���).
    public float rotationSpeed = 30f; // �������� �������� ����.
    public GameObject beePrefab; // ������ �����.
    public int numberOfBees = 10; // ����� ���������� ����.
    public float spawnInterval = 2f; // �������� ����� ��������.
    public Transform spawnPoint; // ������ �� ����� ������ ����.
    public float minDistanceFromHive = 2f; // ����������� ���������� �� ����.
    public float maxDistanceFromHive = 5f; // ������������ ���������� �� ����.
    public BeeCounterText beeCounterText;





    private int beesSpawned = 0;
    private float spawnTimer = 0f;

    void Update()
    {
        // ����� ���� � ����������.
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
        

        Debug.Log("����� �������!");

        // ��������� ��������� ���������� ���������� � ���� ��� ���������� �����.
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
