using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpEspecial : MonoBehaviour
{
    private float time = 0;
    private float timer = 3;

    private bool activo = true;

    
    void Update()
    {
        time += Time.deltaTime;
        if (time > timer)
        {
            time = 0;
            activo = !activo;
            gameObject.GetComponent<Renderer>().enabled = activo;
        }
        
    }
}
