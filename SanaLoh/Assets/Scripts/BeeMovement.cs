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
        // Начальное направление движения - вперед по горизонтали.
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }


    void Update()
    {
        MoveBee();

        // Изменяем направление движения через определенные интервалы времени.
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= changeDirectionInterval)
        {
            randomDirection = Random.insideUnitSphere.normalized;
            elapsedTime = 0f;
        }
    }

    void MoveBee()
    {
        // Получаем горизонтальное направление движения.
        Vector3 horizontalDirection = new Vector3(randomDirection.x, 0f, randomDirection.z).normalized;

        // Перемещаем пчелу в заданном горизонтальном направлении.
        transform.Translate(horizontalDirection * moveSpeed * Time.deltaTime, Space.World);

        // Ограничиваем высоту полёта пчёлы.
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0f, 5f), transform.position.z);
    }



}

