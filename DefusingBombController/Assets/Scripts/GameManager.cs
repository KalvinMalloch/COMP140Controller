using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool countingDown;
    public static int completedModules;
    public float countdownNumber;
    public Text countdownText;

    private void Start()
    {
        countdownText = countdownText.GetComponent<Text>();
    }

    private void CountDown()
    {
        if (countingDown == true)
        {
            countdownNumber = Mathf.Round(countdownNumber * 100f) / 100f;
            countdownText.text = countdownNumber.ToString();
            countdownNumber -= Time.deltaTime;
        }
    }

    private void EndGame()
    {
        if (countdownNumber < 0)
        {
            countdownNumber = 0;
            countdownText.text = countdownNumber.ToString();
            countingDown = false;
            if (completedModules == 6)
            {
                print("You win.");
            }
            else
            {
                print("You blow up.");
            }
        }
    }

    private void Update()
    {
        CountDown();
        EndGame();
        print(completedModules);
    }
}
