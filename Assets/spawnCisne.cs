using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCisne : MonoBehaviour
{
    void Start()
    {
        if (Inventory.Instance.keyItems[2])
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
