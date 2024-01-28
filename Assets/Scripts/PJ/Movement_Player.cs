using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{

    public Animator anim;

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
        

        var newDirection = new Vector2(derecha, arriba).normalized;

        if (derecha > 0)
        {
            transform.localScale = Vector3.one;
            anim.SetInteger("Walk", 1);
        }
        if (derecha < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetInteger("Walk", 1);
        }
        if (arriba > 0)
        {
            anim.SetInteger("Walk", 2);
        }
        if (arriba < 0)
        {
            anim.SetInteger("Walk", 3);
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
