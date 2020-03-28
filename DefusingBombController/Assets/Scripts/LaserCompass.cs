using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;

public class LaserCompass : MonoBehaviour
{
    UduinoManager uduino;

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
        UduinoManager.Instance.pinMode(AnalogPin.A1, PinMode.Input);
        UduinoManager.Instance.pinMode(AnalogPin.A2, PinMode.Input);
        UduinoManager.Instance.pinMode(AnalogPin.A3, PinMode.Input);
        UduinoManager.Instance.pinMode(AnalogPin.A4, PinMode.Input);

        directionIndex = Random.Range(0, compassDirection.Length);
        chosenDirection = compassDirection[directionIndex];
        directionText = directionText.GetComponent<Text>();
        chosenDirectionText = chosenDirectionText.GetComponent<Text>();
    }

    private void CalculateDirection()
    {
        UduinoManager.Instance.analogRead(AnalogPin.A1, "PinRead");
        UduinoManager.Instance.analogRead(AnalogPin.A2, "PinRead");
        UduinoManager.Instance.analogRead(AnalogPin.A3, "PinRead");
        UduinoManager.Instance.analogRead(AnalogPin.A4, "PinRead");

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

        UduinoManager.Instance.SendBundle("PinRead");
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
