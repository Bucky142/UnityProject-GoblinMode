using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetCounters : MonoBehaviour
{
    
    private TextMeshProUGUI killCounterText;
    public int killCount;

    private TextMeshProUGUI goldCounterText;
    public int goldCount;

    // Start is called before the first frame update
    void Start()
    {
        killCounterText = GameObject.Find("KillCounter").GetComponent<TextMeshProUGUI>();
        goldCounterText = GameObject.Find("GoldCounter").GetComponent<TextMeshProUGUI>();
    }

    public void IncrementKillCounter()
    {
        killCount += 1;
        killCounterText.text = ": " + (killCount).ToString();
    }

    public void IncrementGoldCounter()
    {
        goldCount += 1;
        goldCounterText.text = ": " + (goldCount).ToString();
    }
}
