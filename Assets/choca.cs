using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choca : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Inventory>())
        {
            Debug.Log("choco");
        }
    }
}
