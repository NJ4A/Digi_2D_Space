using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPlayer : MonoBehaviour
{
    private bool startRot;
    private bool StopRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if ()
        //{

        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Planet")
        {
            StopRot = true;
        }
    }

}
