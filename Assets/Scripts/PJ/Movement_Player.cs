using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{

    public float velocity;
    private Vector2 direction = Vector2.zero;
    private Rigidbody2D rb;

    void Start()
    {
        transform.position = Inventory.Instance.spawnCoordinates;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float arriba = Input.GetAxis("Vertical");
        float derecha = Input.GetAxis("Horizontal");
        

        var newDirection = new Vector2(derecha, arriba).normalized;
        if (derecha > 0)
        {
            transform.localScale = Vector3.one;
        }
        if (derecha < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        direction = newDirection * velocity;


    }

    private void FixedUpdate()
    {
        rb.velocity = direction;
    }
}
