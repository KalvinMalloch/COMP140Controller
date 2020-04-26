// Kalvin Malloch 2020.
// https://github.com/KalvinMalloch
// MIT License Copyright (c) 2020

// <summary>
// Handles the countdown timer and the amount of completed modules.
// </summary>

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

    /// <summary>
    /// Grabs any necassary text components.
    /// </summary>
    private void Start()
    {
        countdownText = countdownText.GetComponent<Text>();
    }

    /// <summary>
    /// Displays the timer text for the player.
    /// Decreases the timer.
    /// </summary>
    private void CountDown()
    {
        if (countingDown == true)
        {
            countdownNumber = Mathf.Round(countdownNumber * 100f) / 100f;
            countdownText.text = countdownNumber.ToString();
            countdownNumber -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Displays amount of completed modules for the player.
    /// Detects if the player has successfully completed all modules before the timer has run out.
    /// </summary>
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
