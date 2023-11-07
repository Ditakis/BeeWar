using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beehive : MonoBehaviour
{
    public GameObject beePrefab; // Your bee prefab

    void OnMouseDown()
    {
        ShowCreateBeeButton();
    }

    void ShowCreateBeeButton()
    {
        GameObject createBeeButton = GameObject.Find("CreateBeeButton");

        if (createBeeButton != null)
        {
            createBeeButton.SetActive(true);
            // In a real game, you might want to use animations or other effects to show the button
        }
        else
        {
            Debug.LogError("Could not find the object with the create bee button!");
        }
    }

    public void CreateBee()
    {
        // Create a new bee when the button is pressed
        Instantiate(beePrefab, transform.position, Quaternion.identity);
    }
}
