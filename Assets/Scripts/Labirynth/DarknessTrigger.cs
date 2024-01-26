using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DarknessTrigger : MonoBehaviour
{
    public Light2D globalLight;

    public Light2D playerLight;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        globalLight.intensity = 0.1f;

        playerLight.intensity = 1;

        this.gameObject.SetActive(false);
    }
}