using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    public Vector3 spawnCoordinates;

    public Animator transition;

    private float popUpTime = 1f;

    private float resetTime = 1f;

    private float transitionTime = 2f;

    public void Restart()
    {
        StartCoroutine(ResetLevel());
    }

    IEnumerator ResetLevel()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(popUpTime);

        GetComponentInChildren<SpriteRenderer>().enabled = false;

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(resetTime);

        GetComponentInParent<Transform>().position = spawnCoordinates;

        yield return new WaitForSeconds(transitionTime);    
    }
}
