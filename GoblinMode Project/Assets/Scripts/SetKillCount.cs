using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetKillCount : MonoBehaviour
{
    private GameObject killCounterObject;
    private TextMeshProUGUI counter;
    private int killCount;

    // Start is called before the first frame update
    void Start()
    {
        killCounterObject = GameObject.Find("KillCounter");
        counter = killCounterObject.GetComponent<TextMeshProUGUI>();
    }

    public void IncrementCounter()
    {
        killCount += 1;
        counter.text = ": " + (killCount).ToString();
    }
}
