using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeKeeper : MonoBehaviour
{

    private TextMeshProUGUI time;

    private int minutes = 0;
    private string minutesString;

    private int seconds = 0;
    private string secondsString;

    // Start is called before the first frame update

    void Start()
    {
        time = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        minutes = (int)Time.timeSinceLevelLoad / 60;


        // seconds = timePassed - (60 MOD timePassed)
        seconds =  (int)Time.timeSinceLevelLoad % 60;

        FormatTime();

        time.text = minutesString + " : " + secondsString;
    }

    void FormatTime()
    {
        if (minutes >= 10)
        {
            minutesString = minutes.ToString();
        }
        else
        {
            minutesString = "0" + minutes.ToString();
        }

        if (seconds >= 10)
        {
            secondsString = seconds.ToString();
        }
        else
        {
            secondsString = "0" + seconds.ToString();
        }
    }
}
