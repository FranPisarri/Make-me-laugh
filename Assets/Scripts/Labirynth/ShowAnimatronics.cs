using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;

public class ShowAnimatronics : MonoBehaviour
{
    [SerializeField] private float timer = 7f;

    private float time;

    [SerializeField] private float animatronicTime = 2.5f;

    void Start()
    {
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > timer)
        {
            StartCoroutine(AnimatronicTimer());
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    IEnumerator AnimatronicTimer()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        GetComponentInChildren<PolygonCollider2D>().enabled = true;

        yield return new WaitForSeconds(animatronicTime);

        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GetComponentInChildren<PolygonCollider2D>().enabled = false;

        time = 0;
    }
}
