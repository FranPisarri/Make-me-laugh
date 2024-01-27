using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    public Vector3 spawnCoordinates;

    public Transform targetChildren;

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

        GetComponent<KeyItemLostBoy>().ResetLevel();

        targetChildren.GetComponentInChildren<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(popUpTime);

        targetChildren.GetComponentInChildren<SpriteRenderer>().enabled = false;

        transition.SetBool("Start", true);

        yield return new WaitForSeconds(resetTime);

        GetComponent<BoyFollows>().chaseDist = 0f;

        GetComponent<Transform>().position = spawnCoordinates;

        yield return new WaitForSeconds(transitionTime);

        transition.SetBool("Start", false);
    }
}
