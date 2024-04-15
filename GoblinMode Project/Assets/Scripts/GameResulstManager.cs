using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;

public class GameResulstManager : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private int killCount;
    private void Start()
    {
        // creates leaderBoard file if it doesnt exist 
        string filePath = Application.dataPath + "/leaderBoard";

        if(!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
    }
    public void UpdateResultsScreen()
    {
        SetStats();
        UpdateLeaderBoard();
    }
    void SetStats()
    {
        // gets text object from leaderboard screen 
        TextMeshProUGUI timeSurvivedText = GameObject.Find("TimeSurvived").gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI enemiesDefeatedText = GameObject.Find("EnemiesDefeated").gameObject.GetComponent<TextMeshProUGUI>();
        // gets the stats of the current game 
        timerText = GameObject.Find("Timer").gameObject.GetComponent<TextMeshProUGUI>();
        killCount = GameObject.Find("GameUI").gameObject.GetComponent<SetCounters>().killCount;

        timeSurvivedText.text += "       " + timerText.text;
        enemiesDefeatedText.text += "       " + killCount.ToString();
    }

    void UpdateLeaderBoard()
    {
        string filePath = Application.dataPath + "/leaderBoard";
        TextMeshProUGUI leaderBoardText = GameObject.Find("Top10Text").gameObject.GetComponent<TextMeshProUGUI>();

        File.AppendAllText(filePath, timerText.text + "    " + killCount.ToString() + "\n");

        string[] topTen = File.ReadAllLines(filePath);

       
        SortLeaderBoard(ref topTen);
        if (topTen.Length > 10)
        {
            Array.Resize(ref topTen, 10);
        }

        File.WriteAllLines(filePath, topTen);
        leaderBoardText.text = File.ReadAllText(filePath);
    }
    
    void SortLeaderBoard(ref string[] topTen)
    {
        for (int i = 1; i < topTen.Length; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (int.Parse(topTen[j - 1].Substring(11)) < int.Parse(topTen[j].Substring(11)))
                {
                    string temp = topTen[j];
                    topTen[j] = topTen[j - 1];
                    topTen[j - 1] = temp;
                } 
            }
        }
    }


    //void UpdateLeaderBoard()
    //{
    //    string filePath = Application.dataPath + "/leaderBoard";
    //    TextMeshProUGUI leaderBoardText = GameObject.Find("Top10Text").gameObject.GetComponent<TextMeshProUGUI>();

    //    File.AppendAllText(filePath, Time.timeSinceLevelLoad.ToString() +";" + killCount.ToString() + "\n");

        
    //    string[] topTen = File.ReadAllText(filePath).Split(";");

    //    SortLeaderBoard(ref topTen);
    //    if (topTen.Length > 10)
    //    {
    //        Array.Resize(ref topTen, 10);
    //    }

    //    File.WriteAllLines(filePath, topTen);
    //    leaderBoardText.text = File.ReadAllText(filePath);
    //}

    //void SortLeaderBoard(ref string[] topTen)
    //{
    //    for (int i = 1; i < topTen.Length; i++)
    //    {
    //        for (int j = i; j > 0; j--)
    //        {
    //            if (int.Parse(0.20.Substring(11)) < int.Parse(topTen[j].Substring(11)))
    //            {
    //                string temp = topTen[j];
    //                topTen[j] = topTen[j - 1];
    //                topTen[j - 1] = temp;
    //            }
    //        }
    //    }
    //}
}
