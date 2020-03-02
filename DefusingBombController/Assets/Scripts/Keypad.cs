﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public string[] keypadNumbers = new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
    public string chosenKeypadNumber;
    public bool moduleCompleted;
    public bool minusModuleCompleted;
    public InputField keypadNumber;
    public Text chosenKeypadText;

    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            chosenKeypadNumber = chosenKeypadNumber + Random.Range(0, keypadNumbers.Length);
        }
        chosenKeypadText = chosenKeypadText.GetComponent<Text>();
    }

    private void CalculateKeypad()
    {
        chosenKeypadText.text = "Keypad: " + chosenKeypadNumber;
        if (string.Compare(keypadNumber.text, chosenKeypadNumber) == 0 & moduleCompleted == false)
        {
            GameManager.completedModules = GameManager.completedModules + 1;
            moduleCompleted = true;
            minusModuleCompleted = true;
        }
        else if (string.Compare(keypadNumber.text, chosenKeypadNumber) == -1 & minusModuleCompleted == true)
        {
            GameManager.completedModules = GameManager.completedModules - 1;
            minusModuleCompleted = false;
            moduleCompleted = false;
        }
    }

    void Update()
    {
        CalculateKeypad();
    }
}
