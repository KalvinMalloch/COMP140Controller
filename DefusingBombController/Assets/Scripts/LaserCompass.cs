// Kalvin Malloch 2020.
// https://github.com/KalvinMalloch
// MIT License Copyright (c) 2020

// <summary>
// Handles the input and detection of the photoresistors (bottom left).
// </summary>

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

    /// <summary>
    /// Detects any specified pin inputs and then grabs any necassary text components.
    /// Also randomises initial direction the player has to match.
    /// </summary>
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

    /// <summary>
    /// Displays any text beneficial for the player.
    /// Detects if the player has successfully matched the direction.
    /// </summary>
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

    /// <summary>
    /// Provides keyboard input for when the Arduino isn't available.
    /// Also changes the direction based on how much light a photoresistor is recieving.
    /// </summary>
    private void ChooseDirection()
    {

        if (Input.GetKey(KeyCode.W) || UduinoManager.Instance.analogRead(AnalogPin.A1, "PinRead") >= 20)
        {
            currentDirection = compassDirection[0];
        }
        if (Input.GetKey(KeyCode.D) || UduinoManager.Instance.analogRead(AnalogPin.A2, "PinRead") >= 20)
        {
            currentDirection = compassDirection[1];
        }
        if (Input.GetKey(KeyCode.S) || UduinoManager.Instance.analogRead(AnalogPin.A3, "PinRead") >= 20)
        {
            currentDirection = compassDirection[2];
        }
        if (Input.GetKey(KeyCode.A) || UduinoManager.Instance.analogRead(AnalogPin.A4, "PinRead") >= 20)
        {
            currentDirection = compassDirection[3];
        }

        UduinoManager.Instance.SendBundle("PinRead");
    }

    void Update()
    {
        CalculateDirection();
        ChooseDirection();
    }
}
