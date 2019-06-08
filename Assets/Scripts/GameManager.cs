using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public delegate void GeneralMethod();
    public static event GeneralMethod OnWon;
    public static event GeneralMethod OnReset;
    public float timeElapsed = 0;
    public bool isPaused = false;
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
    public void Win()
    {
        if(OnWon != null)
        {
            OnWon();
        }
        isPaused = true;
    }
    public void Reset()
    {
        if(OnReset != null)
        {
            OnReset();
        }

    }
    public void StartGame()
    {

    }
    public void Update()
    {
        if(!isPaused)
        {
            timeElapsed += Time.deltaTime;
        }
    }

}
