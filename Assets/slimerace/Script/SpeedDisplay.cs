using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public Text speedText; // UI Text element to display the speed

    private void Update()
    {
        // Access the static Speed variable from the RaceGameManager directly using the class name
        float speedInKmPerSecond = RaceGameManager.Speed * 0.01f; // Convert m/s to km/s
        speedText.text = "Speed: " + speedInKmPerSecond.ToString("F2") + " km/s";
    }
}