using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShip : MonoBehaviour
{
    public Vector2 movePoint1;
    public Vector2 movePoint2;
    private Vector2 movePoint;
    public float speed;

    void Start()
    {
        movePoint = movePoint2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= movePoint1.x)
        {
            movePoint = movePoint2;
        }
        if (transform.position.x >= movePoint2.x)
        {
            movePoint = movePoint1;
        }

        transform.Translate(new Vector2(movePoint.x - transform.position.x, movePoint.y - transform.position.y).normalized*speed*Time.deltaTime);
        
    }
}
