using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float changeDirectionInterval = 2f;

    private float elapsedTime = 0f;
    private Vector3 randomDirection;

    void Start()
    {
        // ��������� ����������� �������� - ������ �� �����������.
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }


    void Update()
    {
        MoveBee();

        // �������� ����������� �������� ����� ������������ ��������� �������.
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= changeDirectionInterval)
        {
            randomDirection = Random.insideUnitSphere.normalized;
            elapsedTime = 0f;
        }
    }

    void MoveBee()
    {
        // �������� �������������� ����������� ��������.
        Vector3 horizontalDirection = new Vector3(randomDirection.x, 0f, randomDirection.z).normalized;

        // ���������� ����� � �������� �������������� �����������.
        transform.Translate(horizontalDirection * moveSpeed * Time.deltaTime, Space.World);

        // ������������ ������ ����� �����.
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0f, 5f), transform.position.z);
    }



}

