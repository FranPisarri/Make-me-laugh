using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidTrap : MonoBehaviour
{
    public List<Transform> children;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LostBoy")
        {
            foreach (Transform t in children)
            {
                t.GetComponentInChildren<MidTrapActivated>().TrapActivated();
            }
        }
    }
}
