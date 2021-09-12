using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text time;
    public Text items;
    public Text countdown;
    private float timer = 4;
    private float TimerWorld = 0;
    public bool countdownEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int seconds = (int)timer % 60;

        if (countdownEnded == false)
        {
            countdown.text = seconds.ToString();

            if (seconds == 0)
            {
                countdownEnded = true;
                countdown.text = string.Empty;
            }
        }
        else
        {
            TimerWorld += Time.deltaTime;
            float seconds2 = TimerWorld % 60;
            int mins = (int)TimerWorld / 60;
            time.text = "Time: " + mins.ToString() + ":" + seconds2.ToString("F1");
            items.text = "Food Eaten: " + ManagerClass.itemsCollected;
        }

    }
}
