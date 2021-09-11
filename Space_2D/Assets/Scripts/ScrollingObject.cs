using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    /*private Rigidbody2D rigidBody;
    private float m_speed = -.5f;
    [SerializeField]  private bool m_stopScrolling;

    private float camLocX, camLocY, camSpdX, camSpdY;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(m_speed, m_speed);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (m_stopScrolling)
            rigidBody.velocity = Vector2.zero;
        else
            rigidBody.velocity = new Vector2(m_speed, m_speed);
    }
    */

    public float speed = 1;
    private RectTransform rt;
    private void Start()
    {
        rt = GetComponent<RectTransform>();
        
    }

    private void Update()
    {
        
        rt.Rotate(new Vector3(0, 0, speed * Time.deltaTime));

    }
}
