using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogTrigger : MonoBehaviour
{

    
    private bool isTrigger;
    public bool IsTrigger => isTrigger;


    public GameObject Msg;
    public GameObject Dialog;


    private GameObject pj = null;
    private void Start()
    {
        isTrigger = false;
    }
    void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pj.GetComponent<Movement_Player>().enabled = false;
                Dialog.SetActive(true);

            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entr�");
        if (collision != null)
        {
            pj = collision.gameObject;
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
