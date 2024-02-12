using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;

public class GameResulstScript : MonoBehaviour
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
        timerText = GameObject.Find("Timer").gameObject.GetComponent<TextMeshProUGUI>();
        killCount = GameObject.Find("GameUI").gameObject.GetComponent<SetCounters>().killCount;

        SetStats();
        UpdateLeaderBoard();
    }
    void SetStats()
    {
        // gets text object from leaderboard screen 
        TextMeshProUGUI timeSurvivedText = GameObject.Find("TimeSurvived").gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI enemiesDefeatedText = GameObject.Find("EnemiesDefeated").gameObject.GetComponent<TextMeshProUGUI>();
        // gets the stats of the current game 
        TextMeshProUGUI timerText = GameObject.Find("Timer").gameObject.GetComponent<TextMeshProUGUI>();
        int killCount = GameObject.Find("GameUI").gameObject.GetComponent<SetCounters>().killCount;

        timeSurvivedText.text += "       " + timerText.text;
        enemiesDefeatedText.text += "       " + killCount.ToString();
    }

    void UpdateLeaderBoard()
    {
        string filePath = Application.dataPath + "/leaderBoard";
        TextMeshProUGUI leaderBoardText = GameObject.Find("Top10Text").gameObject.GetComponent<TextMeshProUGUI>();

        File.AppendAllText(filePath, timerText.text + "    " + killCount.ToString() + "\n");

        string[] TopTen = File.ReadAllLines(filePath);

       
        SortLeaderBoard(ref TopTen);
        if (TopTen.Length > 10)
        {
            Array.Resize(ref TopTen, 10);
        }

        File.WriteAllLines(filePath, TopTen);
        leaderBoardText.text = File.ReadAllText(filePath);
    }
    
    void SortLeaderBoard(ref string[] TopTen)
    {
        for (int i = 1; i < TopTen.Length; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (int.Parse(TopTen[j - 1].Substring(11)) < int.Parse(TopTen[j].Substring(11)))
                {
                    string temp = TopTen[j];
                    TopTen[j] = TopTen[j - 1];
                    TopTen[j - 1] = temp;
                } 
            }
        }
    }
}
