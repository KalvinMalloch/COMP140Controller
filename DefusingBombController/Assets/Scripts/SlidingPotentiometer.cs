﻿// Kalvin Malloch 2020.
// https://github.com/KalvinMalloch
// MIT License Copyright (c) 2020

// <summary>
// Handles the input and detection of the sliding potentiometer (top left).
// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;

public class SlidingPotentiometer : MonoBehaviour
{
    UduinoManager uduino;

    public int slidingChosenNumber;
    public bool moduleCompleted;
    public bool minusModuleCompleted;
    public Slider potenSlider;
    public Text slidingChosenText;
    public Text slidingPotenText;

    /// <summary>
    /// Detects any specified pin inputs and then grabs any necassary text components.
    /// Also randomises initial number the player has to match.
    /// </summary>
    void Start()
    {
        UduinoManager.Instance.pinMode(AnalogPin.A0, PinMode.Input);

        slidingChosenNumber = Random.Range(1, 100);
        slidingChosenText = slidingChosenText.GetComponent<Text>();
        slidingPotenText = slidingPotenText.GetComponent<Text>();
        slidingChosenText.text = "Numeral: " + slidingChosenNumber.ToString();
    }

    /// <summary>
    /// Translates pin input value and displays any text beneficial for the player.
    /// Detects if the player has successfully matched the number.
    /// </summary>
    private void CalculateSlider()
    {
        potenSlider.value = (UduinoManager.Instance.analogRead(AnalogPin.A0, "PinRead")) / 10;

        slidingPotenText.text = potenSlider.value.ToString();
        if (potenSlider.value == slidingChosenNumber & moduleCompleted == false)
        {
            GameManager.completedModules = GameManager.completedModules + 1;
            moduleCompleted = true;
            minusModuleCompleted = true;
        }
        else if (potenSlider.value != slidingChosenNumber & minusModuleCompleted == true)
        {
            GameManager.completedModules = GameManager.completedModules - 1;
            minusModuleCompleted = false;
            moduleCompleted = false;
        }

        UduinoManager.Instance.SendBundle("PinRead");
    }

    void Update()
    {
        CalculateSlider();
    }
}
