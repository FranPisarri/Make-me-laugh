using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCDialogTrigger : MonoBehaviour
{
    public UnityEvent Onhit = new UnityEvent();

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
                Onhit.Invoke();

                pj.GetComponent<Movement_Player>().enabled = false;
                Dialog.SetActive(true);

            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entró");
        if (collision != null)
        {
            pj = collision.gameObject;
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
