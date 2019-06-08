using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text timerText;
    public GameObject winScreen;
    public GameObject loseScreen;
    public Text winText;
    void UpdateTimer()
    {

    }
    void OnDisable()
    {
        GameManager.OnWon -= ShowWinScreen;
        GameManager.OnLose -= ShowLoseScreen;
    }

    private void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }

    void OnEnable()
    {
        GameManager.OnWon += ShowWinScreen;
        GameManager.OnLose += ShowLoseScreen;

    }

    private void ShowWinScreen()
    {
        winText.text = "You solved the cube in " + (int)GameManager.instance.timeElapsed + " seconds!";
        winScreen.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = (int)GameManager.instance.GetCurrTime() + "";
    }
}
