using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTrigger : MonoBehaviour
{

    private bool isTrigger;
    public GameObject Msg;


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
                for (int i = 0;i < Inventory.Instance.cards.Length; i++)
                {
                    if (!Inventory.Instance.cards[i])
                    {
                        Inventory.Instance.cards[i] = true;
                        i= Inventory.Instance.cards.Length;
                    }
                }
                
                this.gameObject.SetActive(false);

            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entró");
        if (collision != null)
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
