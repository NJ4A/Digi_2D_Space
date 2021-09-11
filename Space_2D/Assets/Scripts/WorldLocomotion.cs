using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLocomotion : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public bool negRotation = false;
    public bool StopRotation = false; 

    // Update is called once per frame
    void Update()
    {
        if (StopRotation == false)
        {
            if (negRotation)
            {
                transform.Rotate(0, 0, -speed);
            }
            else
            {
                transform.Rotate(0, 0, speed);
            }
        }
    }
}
