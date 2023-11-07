using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBoundary : MonoBehaviour
{
    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;

    void Update()
    {
        // Ограничиваем позицию пчёл в пределах заданных границ.
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            Mathf.Clamp(transform.position.z, minZ, maxZ)
        );
    }
}

