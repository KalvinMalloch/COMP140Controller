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

    private void CalculateDirection()
    {
        directionText.text = "Compass: " + chosenDirection;
        chosenDirectionText.text = "Direction: " + currentDirection;
        if (string.Compare(currentDirection, chosenDirection) == 0 & moduleCompleted == false)
        {
            GameManager.completedModules = GameManager.completedModules + 1;
            moduleCompleted = true;
            minusModuleCompleted = true;
        }
        else if (string.Compare(currentDirection, chosenDirection) == -1 & minusModuleCompleted == true)
        {
            GameManager.completedModules = GameManager.completedModules - 1;
            minusModuleCompleted = false;
            moduleCompleted = false;
        }
    }

    private void ChooseDirection()
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
        CalculateDirection();
        ChooseDirection();
    }
}
