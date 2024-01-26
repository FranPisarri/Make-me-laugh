using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTimer : MonoBehaviour
{
    private float timer;
    private float time;
    void Start()
    {
        time = 0;
        timer = gameObject.GetComponentInParent<PopUpRandomMsg>().timer+2;
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > timer)
        {
            time = 0;
            this.gameObject.SetActive(false);
        }
    }
}
