using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLocomotion : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpSpeed;
    private float jumpTimeUp;
    private float jumpTimeDown;
    public float startJumpTime;
    private bool isJumping = false;
    private bool isGoingBack = false;
    private WorldLocomotion currentWorld;
    private bool doIneedToRotate;
    private LineRenderer lr;
    public UI readyToPlay;
    private Animator anim;
    private AudioSource boing;

    void Start()
    {
        boing = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jumpTimeUp = startJumpTime;
        jumpTimeDown = startJumpTime;
        SetBool(ref ManagerClass.didPlayerSwitchPlanet);
        currentWorld = GetComponentInParent<WorldLocomotion>();
        if (currentWorld != null)
        {
            Debug.Log("got it");
        }
        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Additive"));
        lr.endColor = Color.white;
        lr.startColor = Color.red;
        lr.startWidth = .2f;
        lr.positionCount = 2;
    }

    void SetBool(ref bool _bool) 
    {
        doIneedToRotate = _bool;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("ItemsCollected", (int)ManagerClass.itemsCollected);

        if (readyToPlay.countdownEnded == true)
        {
            if (!isJumping)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isJumping = true;
                    currentWorld.StopRotation = true;
                    boing.Play();
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
                //transform.localRotation = Quaternion.identity;
                //transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            transform.Rotate(Vector3.forward * (80 * Time.deltaTime));
        }

        
        // AdjustPlayer();
    }

    private void FixedUpdate()
    {
        if (ManagerClass.itemsCollected > 44)
        {
            ManagerClass.Score = readyToPlay.time.text;
            SceneManager.LoadScene("CreditsScreen");
        }
    }

    void AdjustPlayer()
    {
            Vector3 origin = transform.position;
            Vector3 direction = transform.TransformDirection(Vector3.down);
            Vector3 endPoint = origin + direction * 100000;
            RaycastHit2D hit = Physics2D.Raycast(origin, direction);

            //DEBUG
            //lr.SetPosition(0, origin);

            if (hit)
            {
            endPoint = hit.point;
            if (hit.transform.tag == "Planet")
                {
                    endPoint = hit.point;
                }
            }
            else
            {
                transform.Rotate(Vector3.forward * Time.deltaTime);
            }

            //lr.SetPosition(1, endPoint);
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
