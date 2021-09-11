using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    // double the spin speed when true
    private bool fastSpin = false;


    // Update is called once per frame
    void Update()
    {
 

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Floating");
            anim.Play("float");
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Jumping");
            anim.Play("jump");
        }

    }

}
