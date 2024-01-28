using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TriggerShip : MonoBehaviour
{
    public GameObject ship;

    public GameObject Msg;
    public Vector2 newDestination;
    private bool isTrigger;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(ship.transform.position.y > newDestination.y - 4)
                {
                    ship.GetComponent<SpriteRenderer>().sprite = ship.GetComponent<MovementShip>().moveDown;
                }
                else
                {
                    ship.GetComponent<SpriteRenderer>().sprite = ship.GetComponent<MovementShip>().moveUp;
                }
                ship.GetComponent<MovementShip>().movePoint = newDestination;
                Msg.GetComponent<SpriteRenderer>().enabled = false;
                
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entr�");
        if (collision.GetComponent<Movement_Player>())
        {
            isTrigger = true;
            Msg.SetActive(true);
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Sali�");
        if (collision != null)
        {
            isTrigger = false;
            Msg.SetActive(false);
        }

    }
}
