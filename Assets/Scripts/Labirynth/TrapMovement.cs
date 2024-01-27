using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TrapMovement : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;

    [SerializeField] private float lightTimer = 1f;

    private bool coroutine = false;

    private void Update()
    {
        if (coroutine == false)
        {
            StartCoroutine(Rotate());
        }
    }

    IEnumerator Rotate()
    {
        coroutine = true;

        pos1.GetComponentInChildren<PolygonCollider2D>().enabled = true;
        pos1.GetComponent<Light2D>().enabled = true;

        yield return new WaitForSeconds(lightTimer);

        pos1.GetComponentInChildren<PolygonCollider2D>().enabled = false;
        pos1.GetComponent<Light2D>().enabled = false;

        pos2.GetComponentInChildren<PolygonCollider2D>().enabled = true;
        pos2.GetComponent<Light2D>().enabled = true;

        yield return new WaitForSeconds(lightTimer);

        pos2.GetComponentInChildren<PolygonCollider2D>().enabled = false;
        pos2.GetComponent<Light2D>().enabled = false;

        pos3.GetComponentInChildren<PolygonCollider2D>().enabled = true;
        pos3.GetComponent<Light2D>().enabled = true;

        yield return new WaitForSeconds(lightTimer);

        pos3.GetComponentInChildren<PolygonCollider2D>().enabled = false;
        pos3.GetComponent<Light2D>().enabled = false;

        pos4.GetComponentInChildren<PolygonCollider2D>().enabled = true;
        pos4.GetComponent<Light2D>().enabled = true;

        yield return new WaitForSeconds(lightTimer);

        pos4.GetComponentInChildren<PolygonCollider2D>().enabled = false;
        pos4.GetComponent<Light2D>().enabled = false;

        coroutine = false;
    }
}
