using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotaryKnob : MonoBehaviour
{
    public Text chosenRotaryText;
    public int firstRotaryNumber;
    public int secondRotaryNumber;

    void Start()
    {
        chosenRotaryText = chosenRotaryText.GetComponent<Text>();
        firstRotaryNumber = Random.Range(1, 360);
        secondRotaryNumber = Random.Range(1, 360);
    }

    void CalculateRotary()
    {

    }

    void Update()
    {
        CalculateRotary();
    }
}
