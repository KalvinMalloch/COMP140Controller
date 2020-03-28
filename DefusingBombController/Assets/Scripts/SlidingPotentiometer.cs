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

    void Start()
    {
        UduinoManager.Instance.pinMode(AnalogPin.A0, PinMode.Input);

        slidingChosenNumber = Random.Range(1, 100);
        slidingChosenText = slidingChosenText.GetComponent<Text>();
        slidingPotenText = slidingPotenText.GetComponent<Text>();
        slidingChosenText.text = "Numeral: " + slidingChosenNumber.ToString();
    }

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
