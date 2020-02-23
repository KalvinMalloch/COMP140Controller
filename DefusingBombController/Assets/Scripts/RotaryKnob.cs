using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotaryKnob : MonoBehaviour
{
    public Text chosenRotaryText;
    public Text currentRotaryOneText;
    public Text currentRotaryTwoText;
    public int firstChosenRotaryNumber;
    public int secondChosenRotaryNumber;
    public int firstRotaryNumber;
    public int secondRotaryNumber;
    public bool moduleCompleted;
    public bool minusModuleCompleted;

    void Start()
    {
        chosenRotaryText = chosenRotaryText.GetComponent<Text>();
        currentRotaryOneText = currentRotaryOneText.GetComponent<Text>();
        currentRotaryTwoText = currentRotaryTwoText.GetComponent<Text>();
        firstChosenRotaryNumber = Random.Range(1, 360);
        secondChosenRotaryNumber = Random.Range(1, 360);
    }

    void CalculateRotary()
    {
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

    void ChooseRotation()
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
