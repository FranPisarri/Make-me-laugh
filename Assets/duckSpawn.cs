using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class duckSpawn : MonoBehaviour
{
    public int cardNumber;

    private void Start()
    {
        if (Inventory.Instance.cards[cardNumber])
        {
            gameObject.SetActive(false);

        }
    }
}
