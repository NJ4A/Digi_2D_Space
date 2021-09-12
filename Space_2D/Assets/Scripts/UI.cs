using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text time;
    public Text items;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int)timer % 60;
        time.text = "Time: " + seconds.ToString();
        items.text = "Items Collected: " + ManagerClass.itemsCollected;
    }
}
