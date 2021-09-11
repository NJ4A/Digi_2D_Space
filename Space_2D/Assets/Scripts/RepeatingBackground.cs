using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D m_backgroundCollider;
    private float m_BackgroundSizeY;
    private float m_BackgroundSizeX;

    


    void Start()
    {
        m_backgroundCollider = GetComponent<BoxCollider2D>();
        m_BackgroundSizeY = m_backgroundCollider.size.y;
        m_BackgroundSizeX = m_backgroundCollider.size.x;

    }

    
    void Update()
    {

        if (transform.position.y < -m_BackgroundSizeY)
            RepeatBackgroundY();
        if (transform.position.x < -m_BackgroundSizeX)
            RepeatBackgroundX();
    }

    void RepeatBackgroundY()
    {
        Vector2 BG_offset = new Vector2(0, m_BackgroundSizeY * 2f);
        transform.position = (Vector2)transform.position + BG_offset;
    }

    void RepeatBackgroundX()
    {
        Vector2 BG_offset = new Vector2(m_BackgroundSizeX * 2f, 0);
        transform.position = (Vector2)transform.position + BG_offset;
    }
}
