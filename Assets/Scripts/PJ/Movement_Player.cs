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
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        float arriba = Input.GetAxis("Vertical");
        float derecha = Input.GetAxis("Horizontal");
        

        var newDirection = new Vector2(derecha, arriba).normalized;

        if (derecha > 0)
        {
            transform.localScale = Vector3.one;
            anim.SetTrigger("Side");
            anim.SetBool("Idle", false);
        }
        if (derecha < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetTrigger("Side");
            anim.SetBool("Idle", false);
        }
        if (arriba > 0)
        {
            anim.SetTrigger("Up");
            anim.SetBool("Idle", false);
        }
        if (arriba < 0)
        {
            anim.SetTrigger("Down");
            anim.SetBool("Idle", false);
        }
        if (derecha == 0 && arriba == 0)
        {
            anim.SetBool("Idle", true);
        }

        direction = newDirection * velocity;


    }

    private void FixedUpdate()
    {
        rb.velocity = direction;
    }
}
