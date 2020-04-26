// Kalvin Malloch 2020.
// https://github.com/KalvinMalloch
// MIT License Copyright (c) 2020

// <summary>
// Handles the rotation and detection of the rotary encoder (bottom right).
// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class RotaryCircle : MonoBehaviour
{
    UduinoManager uduino;

    public GameObject circleStageOne;
    public GameObject circleStageTwo;
    public Transform circleRotation;
    public int buttonPressed;
    public bool startDelay;
    public bool stageOne;
    public bool stageTwo;
    public bool endTurning;

    public int test;

    /// <summary>
    /// Detects any specified pin inputs.
    /// </summary>
    void Start()
    {

        buttonPressed = 1;
        UduinoManager.Instance.pinMode(2, PinMode.Input_pullup);
    }

    /// <summary>
    /// Detects if the player has moved to the next state of rotation.
    /// </summary>
    private void CalculateRotaryCircle()
    {
        if (stageOne == false)
        {
            circleRotation = circleStageOne.transform;
        }
        if (stageOne == true)
        {
            circleRotation = circleStageTwo.transform;
            stageTwo = true;
        }
    }

    /// <summary>
    /// Provides keyboard input for when the Arduino isn't available.
    /// </summary>
    private void ChooseRotaryRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow) & endTurning == false)
        {
            circleRotation.Rotate(0, 0, -5);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) & endTurning == false)
        {
            circleRotation.Rotate(0, 0, 5);
        }
        if (Input.GetKeyDown(KeyCode.Space) || buttonPressed == 0)
        {
            stageOne = true;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || buttonPressed == 0) & (stageTwo == true))
        {
            endTurning = true;
        }
    }

    void Update()
    {
        CalculateRotaryCircle();
        ChooseRotaryRotation();
    }
}
