// Kalvin Malloch 2020.
// https://github.com/KalvinMalloch
// MIT License Copyright (c) 2020

// <summary>
// Handles the rotation and detection of the two potentiometers (top right).
// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;

public class PotenKnobs : MonoBehaviour
{
    UduinoManager uduino;

    public Text chosenRotaryText;
    public Text currentRotaryOneText;
    public Text currentRotaryTwoText;
    public int firstChosenRotaryNumber;
    public int secondChosenRotaryNumber;
    public int firstRotaryNumber;
    public int secondRotaryNumber;
    public bool moduleCompleted;
    public bool minusModuleCompleted;

    int pinA8;
    int pinA9;

    /// <summary>
    /// Detects any specified pin inputs and then grabs any necassary text components.
    /// Also randomises initial numbers the player has to match.
    /// </summary>
    void Start()
    {
        pinA8 = UduinoManager.Instance.GetPinFromBoard("A8");
        pinA9 = UduinoManager.Instance.GetPinFromBoard("A9");
        UduinoManager.Instance.pinMode(pinA8, PinMode.Input);
        UduinoManager.Instance.pinMode(pinA9, PinMode.Input);

        chosenRotaryText = chosenRotaryText.GetComponent<Text>();
        currentRotaryOneText = currentRotaryOneText.GetComponent<Text>();
        currentRotaryTwoText = currentRotaryTwoText.GetComponent<Text>();
        firstChosenRotaryNumber = Random.Range(1, 200);
        secondChosenRotaryNumber = Random.Range(1, 200);
    }

    /// <summary>
    /// Translates pin input value and displays any text beneficial for the player.
    /// Detects if the player has successfully matched the numbers.
    /// </summary>
    private void CalculateRotary()
    {
        firstRotaryNumber = (UduinoManager.Instance.analogRead(pinA8)) / 5;
        secondRotaryNumber = (UduinoManager.Instance.analogRead(pinA9)) / 5;

        chosenRotaryText.text = "Rotations: " + firstChosenRotaryNumber.ToString() + " & " + secondChosenRotaryNumber.ToString();
        currentRotaryOneText.text = firstRotaryNumber.ToString();
        currentRotaryTwoText.text = secondRotaryNumber.ToString();
        if (firstChosenRotaryNumber == firstRotaryNumber & secondChosenRotaryNumber == secondRotaryNumber & moduleCompleted == false)
        {
            GameManager.completedModules = GameManager.completedModules + 1;
            moduleCompleted = true;
            minusModuleCompleted = true;
        }
        else if (firstChosenRotaryNumber != firstRotaryNumber & secondChosenRotaryNumber != secondRotaryNumber & moduleCompleted == true)
        {
            GameManager.completedModules = GameManager.completedModules - 1;
            minusModuleCompleted = false;
            moduleCompleted = false;
        }
    }

    /// <summary>
    /// Provides keyboard input for when the Arduino isn't available.
    /// </summary>
    private void ChooseRotation()
    {
        if (Input.GetKey(KeyCode.R))
        {
            firstRotaryNumber++;
        }
        if (Input.GetKey(KeyCode.F))
        {
            firstRotaryNumber--;
        }
        if (Input.GetKey(KeyCode.T))
        {
            secondRotaryNumber++;
        }
        if (Input.GetKey(KeyCode.G))
        {
            secondRotaryNumber--;
        }
    }

    void Update()
    {
        CalculateRotary();
        ChooseRotation();
    }
}
