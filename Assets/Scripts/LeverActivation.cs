using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivation : MonoBehaviour
{

    private bool isTrigger;
    public GameObject Msg;
    public GameObject clown;
    public Sprite laverActivated;
    public Sprite wetClown;
    public ItemName keyObject;

    [SerializeField] private GameObject slider;


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
               // pj.GetComponent<Movement_Player>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = laverActivated;
                clown.GetComponent<SpriteRenderer>().sprite = wetClown;
                Msg.SetActive(false);
                Inventory.Instance.keyItems[(int)keyObject] = true;
                Inventory.Instance.misionCheck[(int)keyObject] = true;
                slider.GetComponent<LaughProgres>().SetSliderValue();
                Inventory.Instance.FinishGame();
                this.enabled = false;

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
