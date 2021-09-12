using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WiggleObject : MonoBehaviour
{
    public int wiggleSpeed = 3;
    public float wiggleDistance = 1f;
    private int wiggleVal = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (wiggleVal < wiggleSpeed)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y + wiggleDistance), Time.deltaTime);
            wiggleVal++;
        }
        else if (wiggleVal < wiggleSpeed * 2)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y - wiggleDistance), Time.deltaTime);
            wiggleVal++;
        }
        else { wiggleVal = 0; }
    }
}
