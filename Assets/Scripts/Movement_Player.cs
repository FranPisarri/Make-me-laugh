using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{

    public float velocity;
    void Start()
    {
        
    }


    void Update()
    {
        float arriba = Input.GetAxis("Vertical");
        float derecha = Input.GetAxis("Horizontal");
        float deltaTime = Time.deltaTime;
        if (arriba > 0)
        {
            transform.Translate(0, velocity * deltaTime, 0);
        }
        if (arriba < 0)
        {
            transform.Translate(0, -velocity * Time.deltaTime, 0);
        }
        if (derecha > 0)
        {
            transform.Translate(velocity * Time.deltaTime, 0, 0);
            transform.localScale = Vector3.one;
        }
        if (derecha < 0)
        {
            transform.Translate(-velocity * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }



    }
}
