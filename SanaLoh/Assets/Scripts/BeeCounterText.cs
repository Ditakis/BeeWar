using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeCounterText : MonoBehaviour
{
    public Text beeCountText;
    private int beeCount = 0;

    void Start()
    {
        UpdateBeeCountText();
    }

    public void IncreaseBeeCount()
    {
        beeCount++;
        UpdateBeeCountText();
        Debug.Log("���������� �������� ����. ������� ��������: " + beeCount);
    }


    void UpdateBeeCountText()
    {
        beeCountText.text = "�����: " + beeCount;
        Debug.Log("������� ������� ����: " + beeCount);
    }

}

