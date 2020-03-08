using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPoten : MonoBehaviour
{
    public Toggle[] keyToggles;
    public Text chosenKeyText;
    public int chosenPotenNumber;
    public bool moduleCompleted;
    public bool minusModuleCompleted;

    void Start()
    {
        chosenPotenNumber = Random.Range(1, 3);
        chosenKeyText = chosenKeyText.GetComponent<Text>();
    }

    private void CalculateKeys()
    {
        chosenKeyText.text = "Key: Key " + chosenPotenNumber;
        if (chosenPotenNumber == 1 & keyToggles[0].isOn == true & moduleCompleted == false)
        {
            GameManager.completedModules = GameManager.completedModules + 1;
            moduleCompleted = true;
            minusModuleCompleted = true;
        }
        else if (chosenPotenNumber == 2 & keyToggles[1].isOn == true & moduleCompleted == false)
        {
            GameManager.completedModules = GameManager.completedModules + 1;
            moduleCompleted = true;
            minusModuleCompleted = true;
        }
        else if (chosenPotenNumber == 3 & keyToggles[2].isOn == true & moduleCompleted == false)
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

    void Update()
    {
        CalculateKeys();
    }
}
