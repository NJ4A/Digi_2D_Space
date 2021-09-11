using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
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
