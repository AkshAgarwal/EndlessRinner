using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerManager : MonoBehaviour
{
    #region Timer and UI references
    //UI Component data members
    [SerializeField] private TextMeshProUGUI Timer;
    [SerializeField] private TextMeshProUGUI Score;

    //Timer data members
       private  float           minutes;
       private  float           seconds;
       private  float           score;
    #endregion

    void Start()
    {
        minutes = 0f;
        seconds = 0f;
        score   = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //To increment minutes and seconds of the timer.

        Timer.SetText(minutes.ToString("0") + " : " + seconds.ToString("0"));
        seconds += Time.deltaTime;
        if(seconds>=60)
        {
            minutes++;
            seconds = 0f;
        }

        // To increment the score.

        if(seconds%5>=0 && seconds%5<=0.005)
        {
            score++;
            Score.SetText("Score: " + score.ToString("0"));
           // PlayerMovement.instance.SpeedIncrement();
        }
    }
}
