using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TriggerShip : MonoBehaviour
{
    public GameObject ship;

    public GameObject Msg;

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
                ship.GetComponent<MovementShip>().movePoint = new Vector2(-93,-29);
                this.gameObject.SetActive(false);
                
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entró");
        if (collision.GetComponent<Movement_Player>())
        {
            isTrigger = true;
            Msg.SetActive(true);
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Salió");
        if (collision != null)
        {
            isTrigger = false;
            Msg.SetActive(false);
        }

    }
}
