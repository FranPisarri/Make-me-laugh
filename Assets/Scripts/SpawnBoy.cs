using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoy : MonoBehaviour
{
    void Start()
    {
        if (Inventory.Instance.keyItems[1])
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        
    }

    
}
