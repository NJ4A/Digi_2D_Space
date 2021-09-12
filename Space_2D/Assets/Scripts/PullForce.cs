using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullForce : MonoBehaviour
{
    private Transform Targetplayer;
    private GameObject gb;
    Rigidbody2D playerBody;
    public float influenceRange;
    public float intensity;
    public float distanceToPlayer;
    LineRenderer lr;
    private bool startLerping = false;
    RaycastHit2D hit;
    public bool doesplayerStartOnMe;
    private PlayerLocomotion loco;

    void Start()
    {
        gb = GameObject.Find("Player");
        Targetplayer = gb.transform;
        playerBody = Targetplayer.GetComponent<Rigidbody2D>();
        loco = Targetplayer.GetComponent<PlayerLocomotion>();

        //DEBUG
        lr = Targetplayer.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Additive"));
        lr.endColor = Color.white;
        lr.startColor = Color.red;
        lr.startWidth = .2f;
        lr.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (doesplayerStartOnMe)
        {
            intensity = 0;
            distanceToPlayer = 0;
            influenceRange = 0;
            return;
        }

        if (!doesplayerStartOnMe)
        {
            intensity = .001f;
            influenceRange = 2f;
            distanceToPlayer = Vector2.Distance(Targetplayer.position, transform.position);
            if (distanceToPlayer <= influenceRange)
            {
                Vector3 origin = Targetplayer.transform.position;
                //Vector3 direction = Targetplayer.transform.up;
                Vector3 direction = Targetplayer.transform.TransformDirection(Vector3.up);
                Vector3 endPoint = origin + direction * 100000;
                RaycastHit2D hit = Physics2D.Raycast(origin, direction, 10);

                //DEBUG
                //lr.SetPosition(0, origin);

                if (hit) 
                {
                    endPoint = hit.point;
                    Debug.Log(hit.transform.name);
                    Debug.Log(Targetplayer.transform.position);
                    Debug.Log(hit.point);
                }

               //lr.SetPosition(1, endPoint);


                Targetplayer.parent = transform;
                startLerping = true;
            }

            if (startLerping)
            {
            
                if (!ManagerClass.didPlayerSwitchPlanet)
                {
                    Targetplayer.localPosition = Vector2.Lerp(Targetplayer.localPosition, hit.point, 1 * Time.deltaTime);
                    PlayerLocomotion player = Targetplayer.GetComponent<PlayerLocomotion>(); 
                    player.ResetJump();
                }

                else
                {
                    //Targetplayer.localRotation = Quaternion.identity;
                    //Targetplayer.localRotation = Quaternion.Euler(0, 0, 90);
                    //loco.jumpSpeed = 2;
                    doesplayerStartOnMe = DoIHaveRat();
                    startLerping = false;
                   
                }
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player" && doesplayerStartOnMe == false)
        {
            ManagerClass.didPlayerSwitchPlanet = true;
        }
    }

    public bool DoIHaveRat() 
    {
        PlayerLocomotion tinyRat = transform.GetComponentInChildren<PlayerLocomotion>();

        if (tinyRat != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
