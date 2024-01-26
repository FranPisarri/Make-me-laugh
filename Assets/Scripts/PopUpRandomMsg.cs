using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpRandomMsg : MonoBehaviour
{

    [SerializeField] private GameObject[] popUps;
    private int value;
    private int lastValue;
    [SerializeField] Vector2 limit1;
    [SerializeField] Vector2 limit2;


    private float time;
    public float timer;


    void Update()
    {
        time += Time.deltaTime;
        if (time > timer)
        {
            value = Random.Range(0, popUps.Length);
            while (value == lastValue)
            {
                value = Random.Range(0, popUps.Length);
            }
            popUps[value].transform.position = new Vector2 (Random.Range(limit1.x, limit2.x), Random.Range(limit1.y, limit2.y));
            popUps[value].SetActive(true);
            lastValue = value;
            time = 0;

        }
        
    }
}
