using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{

    public float velocity;
    private Vector2 direction = Vector2.zero;
    void Start()
    {
        
    }


    void Update()
    {
        float arriba = Input.GetAxis("Vertical");
        float derecha = Input.GetAxis("Horizontal");
        float deltaTime = Time.deltaTime;

        float x = 0;
        float y = 0;
        if (arriba > 0)
        {
            y = 1;
            //transform.Translate(0, velocity * deltaTime, 0);
        }
        if (arriba < 0)
        {
            y = -1;
            //transform.Translate(0, -velocity * Time.deltaTime, 0);
        }
        if (derecha > 0)
        {
            x = 1;
            //transform.Translate(velocity * Time.deltaTime, 0, 0);
            transform.localScale = Vector3.one;
        }
        if (derecha < 0)
        {
            x = -1;
            //transform.Translate(-velocity * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if ( x != 0 && y != 0)
        {
            x *= 0.7f;
            y *= 0.7f;
        }

        direction = new Vector2(velocity * x * Time.deltaTime, velocity * y * Time.deltaTime);
        //transform.Translate(velocity * x * Time.deltaTime, velocity * y * Time.deltaTime, 0);



    }

    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().velocity = direction*1000;
        //this.GetComponent<Rigidbody2D>().AddForce(direction*100);
    }
}
