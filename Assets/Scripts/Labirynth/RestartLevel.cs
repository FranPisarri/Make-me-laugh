using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    public Vector3 spawnCoordinates;

    public Animator transition;

    private float popUpTime = 1f;

    private float resetBoyTime = 1f;

    private float transitionTime = 2f;

    public void Restart()
    {
        Debug.Log("ResetLevel");
        StartCoroutine(ResetLevel());
    }

    IEnumerator ResetLevel()
    {
        GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(popUpTime);

        GetComponent<SpriteRenderer>().enabled = false;

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(resetBoyTime);

        GetComponentInParent<Transform>().position = spawnCoordinates;

        yield return new WaitForSeconds(transitionTime);
    }
}
