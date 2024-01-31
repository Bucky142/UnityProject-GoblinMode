using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameResulstScript : MonoBehaviour
{

    public void UpdateResultsScreen()
    {
        SetStats();
    }
    void SetStats()
    {
        GameObject.Find("TimeSurvived").gameObject.GetComponent<TextMeshProUGUI>().text += "            " + GameObject.Find("Timer").gameObject.GetComponent<TextMeshProUGUI>().text;
        GameObject.Find("EnemiesDefeated").gameObject.GetComponent<TextMeshProUGUI>().text += "            " + GameObject.Find("KillCounter").gameObject.GetComponent<TextMeshProUGUI>().text;
    }
}
