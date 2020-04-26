// Kalvin Malloch 2020.
// https://github.com/KalvinMalloch
// MIT License Copyright (c) 2020

// <summary>
// Handles the rotation and detection of the three potentiometers (bottom middle).
// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;

public class KeyPoten : MonoBehaviour
{
    UduinoManager uduino;

    public Toggle[] keyToggles;
    public Text chosenKeyText;
    public int chosenKeyNumber;
    public bool moduleCompleted;
    public bool minusModuleCompleted;

    /// <summary>
    /// Detects any specified pin inputs and then grabs any necassary text components.
    /// Also randomises initial key number the player has to match.
    /// </summary>
    void Start()
    {
        UduinoManager.Instance.GetPinFromBoard("A6");
        UduinoManager.Instance.GetPinFromBoard("A7");
        UduinoManager.Instance.pinMode(AnalogPin.A5, PinMode.Input);
        UduinoManager.Instance.pinMode(AnalogPin.A6, PinMode.Input);
        UduinoManager.Instance.pinMode(AnalogPin.A7, PinMode.Input);

        chosenKeyNumber = Random.Range(1, 3);
        chosenKeyText = chosenKeyText.GetComponent<Text>();
    }

    /// <summary>
    /// Translates pin input value and displays any text beneficial for the player.
    /// Detects if the player has successfully matched the correct key number.
    /// </summary>
    private void CalculateKeys()
    {
        UduinoManager.Instance.analogRead(AnalogPin.A5);
        UduinoManager.Instance.analogRead(AnalogPin.A6);
        UduinoManager.Instance.analogRead(AnalogPin.A7);

        chosenKeyText.text = "Key: Key " + chosenKeyNumber;
        if (chosenKeyNumber == 1 & keyToggles[0].isOn == true & moduleCompleted == false)
        {
            GameManager.completedModules = GameManager.completedModules + 1;
            moduleCompleted = true;
            minusModuleCompleted = true;
        }
        else if (chosenKeyNumber == 2 & keyToggles[1].isOn == true & moduleCompleted == false)
        {
            GameManager.completedModules = GameManager.completedModules + 1;
            moduleCompleted = true;
            minusModuleCompleted = true;
        }
        else if (chosenKeyNumber == 3 & keyToggles[2].isOn == true & moduleCompleted == false)
        {
            GameManager.completedModules = GameManager.completedModules + 1;
            moduleCompleted = true;
            minusModuleCompleted = true;
        }
        else if (minusModuleCompleted == true)
        {
            GameManager.completedModules = GameManager.completedModules - 1;
            minusModuleCompleted = false;
            moduleCompleted = false;
        }
    }

    /// <summary>
    /// Detects the rotation value of the potentiometers and turns toggle values on or off.
    /// </summary>
    private void ChooseKeys()
    {
        if (UduinoManager.Instance.analogRead(AnalogPin.A5) <= 800)
        {
            keyToggles[0].isOn = true;
        } 
        else
        {
            keyToggles[0].isOn = false;
        }
        if (UduinoManager.Instance.analogRead(AnalogPin.A6) <= 800)
        {
            keyToggles[1].isOn = true;
        }
        else
        {
            keyToggles[1].isOn = false;
        }
        if (UduinoManager.Instance.analogRead(AnalogPin.A7) <= 800)
        {
            keyToggles[2].isOn = true;
        }
        else
        {
            keyToggles[2].isOn = false;
        }
    }

    void Update()
    {
        CalculateKeys();
        ChooseKeys();
    }
}
