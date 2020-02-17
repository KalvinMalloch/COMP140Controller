using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool countingDown;
    public float countdownNumber;

    private void Start()
    {
        
    }

    private void countDown()
    {
        countdownNumber -= Time.deltaTime;
    }

    private void Update()
    {
        countDown();
    }
}
