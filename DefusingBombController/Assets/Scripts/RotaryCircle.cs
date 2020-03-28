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
    public bool stageOne;
    public bool stageTwo;
    public bool endTurning;

    void Start()
    {
        UduinoManager.Instance.pinMode(2, PinMode.Input);
        UduinoManager.Instance.pinMode(3, PinMode.Input);
        UduinoManager.Instance.pinMode(4, PinMode.Input_pullup);
    }

    private void CalculateRotaryCircle()
    {
        UduinoManager.Instance.digitalRead(2);
        UduinoManager.Instance.digitalRead(3);
        UduinoManager.Instance.digitalRead(4);

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stageOne = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) & stageTwo == true)
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
