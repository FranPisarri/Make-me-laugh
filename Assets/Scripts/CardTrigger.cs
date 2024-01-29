using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardTrigger : MonoBehaviour
{
    public UnityEvent Onhit = new UnityEvent();

    private bool isTrigger;
    public GameObject Msg;
    public int cardNumber;

    private void Start()
    {
        isTrigger = false;
        if (Inventory.Instance.cards[cardNumber])
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Onhit.Invoke();

                Inventory.Instance.cards[cardNumber] = true;


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
