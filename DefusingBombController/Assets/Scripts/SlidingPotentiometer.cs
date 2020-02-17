using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidingPotentiometer : MonoBehaviour
{
    public int slidingChosenNumber;
    public bool moduleCompleted;
    public bool minusModuleCompleted;
    public static int completedModules;
    public Slider potenSlider;
    public Text slidingChosenText;
    public Text slidingPotenText;

    void Start()
    {
        slidingChosenNumber = Random.Range(1, 100);
        slidingChosenText = slidingChosenText.GetComponent<Text>();
        slidingPotenText = slidingPotenText.GetComponent<Text>();
        slidingChosenText.text = "Numeral: " + slidingChosenNumber.ToString();
    }

    private void calculateSlider()
    {
        slidingPotenText.text = potenSlider.value.ToString();
        if (potenSlider.value == slidingChosenNumber & moduleCompleted == false)
        {
            completedModules = completedModules + 1;
            moduleCompleted = true;
            minusModuleCompleted = true;
        }
        else if (potenSlider.value != slidingChosenNumber & minusModuleCompleted == true)
        {
            completedModules = completedModules - 1;
            minusModuleCompleted = false;
            moduleCompleted = false;
        }
    }

    void Update()
    {
        print(completedModules);
        calculateSlider();
    }
}
