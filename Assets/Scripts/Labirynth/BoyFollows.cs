using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class BoyFollows : MonoBehaviour
{
    private bool isTrigger;

    private GameObject target = null;

    private GameObject pj = null;

    public float Setspeed;

    private float speed;

    public float chaseDist = 0f;

    public float stopDist;

    private float targetDist;

    private void Start()
    {
        isTrigger = false;

        speed = Setspeed;   

        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        targetDist = Vector2.Distance(transform.position, target.transform.position);

        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("chase dist");
                chaseDist = 100f;
            }
        }

        if (targetDist < chaseDist && targetDist > stopDist)
        {
            Debug.Log("chase time");
            ChasePlayer();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            pj = collision.gameObject;

            isTrigger = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            isTrigger = false;
        }
    }

    private void ChasePlayer()
    {
        if (transform.position.x < target.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(2, 2, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-2, 2, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
