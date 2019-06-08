using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public delegate void GeneralMethod();
    public static event GeneralMethod OnWon;
    public static event GeneralMethod OnReset;
    public static event GeneralMethod OnLose;

    public float timeElapsed = 0;
    float maxTime = 90;
    float currTime = 90;
    public bool isPaused = false;
    bool isScrambled = false;
    public float GetCurrTime()
    {
        return currTime;
    }
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetTimeLimit(int time)
    {
        maxTime = time;
        currTime = time;
    }
    public void Win()
    {
        if(OnWon != null)
        {
            OnWon();
        }
        isPaused = true;
    }
    public void Lose()
    {
        if (OnLose != null)
        {
            OnLose();
        }
    }
    public void Reset()
    {
        if(OnReset != null)
        {
            OnReset();
            currTime = maxTime;
            timeElapsed = 0;
        }

    }
    public void Update()
    {
        if(!isPaused && isScrambled)
        {
            timeElapsed += Time.deltaTime;
            currTime -= Time.deltaTime;
            if(currTime <= 0)
            {
                Lose();
            }
        }
    }
    private void SetScrambledFalse()
    {
        isScrambled = false;
    }
    private void SetScrambledTrue()
    {
        isScrambled = true;
    }

    void OnEnable()
    {
        RubikController.OnScrambled += SetScrambledTrue;
        GameManager.OnReset += SetScrambledFalse;

    }

    void OnDisable()
    {
        RubikController.OnScrambled -= SetScrambledTrue;
        GameManager.OnReset -= SetScrambledFalse;
    }

}
