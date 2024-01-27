using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MidTrapActivated : MonoBehaviour
{
    [SerializeField] private float animatronicTime = 2.5f;

    public void TrapActivated()
    {
        StartCoroutine(AnimatronicTimer());
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    IEnumerator AnimatronicTimer()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        GetComponentInChildren<PolygonCollider2D>().enabled = true;
        GetComponentInChildren<Light2D>().enabled = true;

        yield return new WaitForSeconds(animatronicTime);

        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GetComponentInChildren<PolygonCollider2D>().enabled = false;
        GetComponentInChildren<Light2D>().enabled = false;
    }
}
