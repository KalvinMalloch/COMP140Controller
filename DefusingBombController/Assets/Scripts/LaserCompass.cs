using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserCompass : MonoBehaviour
{
    public string[] compassDirection = new string[] { "North", "East", "South", "West" };
    public bool moduleCompleted;
    public bool minusModuleCompleted;
    public int directionIndex;
    public static int completedModules;
    public string chosenDirection;
    public string currentDirection;
    public Text directionText;
    public Text chosenDirectionText;

    void Start()
    {
        directionIndex = Random.Range(0, compassDirection.Length);
        chosenDirection = compassDirection[directionIndex];
        directionText = directionText.GetComponent<Text>();
        chosenDirectionText = chosenDirectionText.GetComponent<Text>();
    }

    private void calculateDirection()
    {
        directionText.text = "Compass: " + chosenDirection;
        chosenDirectionText.text = "Direction: " + currentDirection;
        if (string.Compare(currentDirection, chosenDirection) == 0 & moduleCompleted == false)
        {
            completedModules = completedModules + 1;
            moduleCompleted = true;
            minusModuleCompleted = true;
        }
        else if (string.Compare(currentDirection, chosenDirection) == 1 & minusModuleCompleted == true)
        {
            completedModules = completedModules - 1;
            minusModuleCompleted = false;
            moduleCompleted = false;
        }
    }

    private void chooseDirection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentDirection = compassDirection[0];
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentDirection = compassDirection[1];
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentDirection = compassDirection[2];
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentDirection = compassDirection[3];
        }
    }

    void Update()
    {
        calculateDirection();
        chooseDirection();
    }
}
