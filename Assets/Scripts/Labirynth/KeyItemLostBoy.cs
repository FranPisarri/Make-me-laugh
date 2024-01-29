using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyItemLostBoy : MonoBehaviour
{
    private bool isTrigger;

    public ItemName keyItem;

    private bool resetLevel = false;

    private void Start()
    {
        isTrigger = false;

        if (Inventory.Instance.keyItems[(int)keyItem])
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
                Inventory.Instance.keyItems[(int)keyItem] = true;
            }
        }

        if (resetLevel)
        {
            Inventory.Instance.keyItems[(int)keyItem] = false;
            resetLevel = false;
        }
    }

    public void ResetLevel()
    {
        resetLevel = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            isTrigger = true;
        }
    }
}
