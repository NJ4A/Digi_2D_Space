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
    private float PrevJumpSpeed;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeUp = startJumpTime;
        jumpTimeDown = startJumpTime;
        currentWorld = GetComponentInParent<WorldLocomotion>();
        if (currentWorld != null)
        {
            Debug.Log("got it");
        }
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
                }
                else
                {
                    jumpTimeDown -= Time.deltaTime;
                    applyVelocityWithDirection(transform, true);
                }
            }

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
        //jumpSpeed += ManagerClass.JumpSpeed;
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
