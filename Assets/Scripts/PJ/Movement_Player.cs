using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{

    public Animator anim; 
    // walk 0 --> Idle, 1 --> Side, 2 --> Up, 3 --> Down, 4 --> Fight, 5 --> DiagonalUp, 6 --> DiagonalDown

    public float velocity;
    private Vector2 direction = Vector2.zero;
    private Rigidbody2D rb;

    void Start()
    {
        transform.position = Inventory.Instance.spawnCoordinates;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        float arriba = Input.GetAxis("Vertical");
        float derecha = Input.GetAxis("Horizontal");


        Vector2 newDirection;

        newDirection = new Vector2(0, 0);

        if (derecha > 0)
        {
            transform.localScale = Vector3.one;
            anim.SetInteger("Walk", 1);
            newDirection = new Vector2(derecha, arriba).normalized;
        }
        if (derecha < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetInteger("Walk", 1);
            newDirection = new Vector2(derecha, arriba).normalized;
        }
        if (arriba > 0)
        {
            anim.SetInteger("Walk", 2);
            newDirection = new Vector2(derecha, arriba).normalized;
        }
        if (arriba < 0)
        {
            anim.SetInteger("Walk", 3);
            newDirection = new Vector2(derecha, arriba).normalized;
        }

        if (derecha > 0 && arriba > 0) //arriba derecha
        {
            anim.SetInteger("Walk", 5);
            newDirection = new Vector2(0.866f, 0.45f).normalized;
        }

        if (derecha > 0 && arriba < 0)  //abajo derecha
        {
            anim.SetInteger("Walk", 6);
            newDirection = new Vector2(0.866f, -0.45f).normalized;
        }

        if (derecha < 0 && arriba > 0) //arriba izquierda
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetInteger("Walk", 5);
            newDirection = new Vector2(-0.866f, 0.45f).normalized;
        }

        if (derecha < 0 && arriba < 0) //abajo izquierda
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetInteger("Walk", 6);
            newDirection = new Vector2(-0.866f, -0.45f).normalized;
        }

        if (derecha == 0 && arriba == 0)
        {
            anim.SetInteger("Walk", 0);
        }

        direction = newDirection * velocity;


    }

    private void FixedUpdate()
    {
        rb.velocity = direction;
    }
}
