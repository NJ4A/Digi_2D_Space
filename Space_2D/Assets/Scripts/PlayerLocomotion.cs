using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpSpeed;
    private float jumpTimeUp;
    private float jumpTimeDown;
    public float startJumpTime;
    private bool isJumping = false;
    private bool isGoingBack = false;
    public WorldLocomotion currentWorld;
    private bool doIneedToRotate;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeUp = startJumpTime;
        jumpTimeDown = startJumpTime;
        SetBool(ref ManagerClass.didPlayerSwitchPlanet);
        currentWorld = GetComponentInParent<WorldLocomotion>();
        if (currentWorld != null)
        {
            Debug.Log("got it");
        }
    }

    void SetBool(ref bool _bool) 
    {
        doIneedToRotate = _bool;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                currentWorld.StopRotation = true;
            }
        }
        else
        {
            if (jumpTimeUp <= 0 && !isGoingBack)
            {
                isGoingBack = true;
            }
            else
            {
                jumpTimeUp -= Time.deltaTime;

                if (isJumping)
                {
                    applyVelocityWithDirection(transform, false);
                }
            }


            if (isGoingBack)
            {
                if (jumpTimeDown <= 0)
                {
                    ResetJump();
                    
                    if (ManagerClass.updateSpeed)
                    {
                        ManagerClass.updateSpeed = false;
                        jumpSpeed++;
                    }
                }
                else
                {
                    jumpTimeDown -= Time.deltaTime;
                    applyVelocityWithDirection(transform, true);
                }
            }

        }


        if (ManagerClass.didPlayerSwitchPlanet != doIneedToRotate)
        {
            SetBool(ref ManagerClass.didPlayerSwitchPlanet);
        }
    }


    public void ResetJump() 
    {
        jumpTimeUp = startJumpTime;
        jumpTimeDown = startJumpTime;
        rb.velocity = Vector2.zero;
        isJumping = false;
        isGoingBack = false;
        currentWorld.StopRotation = false;
    }

    public void applyVelocityWithDirection(Transform direction, bool isNeg) 
    {
        if (isNeg)
        {
            rb.velocity = -direction.up * jumpSpeed;
        }
        else
        {
            rb.velocity = direction.up * jumpSpeed;
        }
    }
}
