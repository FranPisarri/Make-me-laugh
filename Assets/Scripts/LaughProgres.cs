using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaughProgres : MonoBehaviour
{
    private float progress;
    void Start()
    {
        progress = 0;
        for (int i = 0; i < Inventory.Instance.misionCheck.Length; i++)
        {
            if (Inventory.Instance.misionCheck[i])
            {
                progress += 0.2f;
            }
        }
        gameObject.GetComponent<Slider>().value = progress;
    }

    public void SetSliderValue()
    {
        progress = 0;
        for (int i = 0; i < Inventory.Instance.misionCheck.Length; i++)
        {
            if (Inventory.Instance.misionCheck[i])
            {
                progress += 0.2f;
            }
        }
        gameObject.GetComponent<Slider>().value = progress;
    }
}
