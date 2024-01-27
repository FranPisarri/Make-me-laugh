using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;

public class ShowAnimatronics : MonoBehaviour
{
    [SerializeField] private float timer = 7f;

    private float time;

    [SerializeField] private float animatronicTime = 2.5f;

    private bool on = false;

    void Start()
    {
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (on)
        {
            if (time > timer)
            {
                StartCoroutine(AnimatronicTimer());
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    public void TurnOn()
    {
        on = true;
        Debug.Log("On");
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

        time = 0;
    }
}
