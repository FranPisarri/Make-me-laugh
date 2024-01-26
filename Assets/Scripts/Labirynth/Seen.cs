using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Seen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LostBoy")
        {
            Debug.Log("seen");
            other.GetComponent<RestartLevel>().Restart();
        }
    }
}
