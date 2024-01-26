using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevel : MonoBehaviour
{
    private bool isTrigger;

    public GameObject Msg;

    public Animator transition;

    public float transitionTime = 1f;

    public string sceneName = null;

    public Vector3 newSpawn;

    private void Start()
    {
        isTrigger = false;
    }
    void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LoadScene();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entró");
        if (collision.GetComponent<Movement_Player>())
        {
            isTrigger = true;
            Msg.SetActive(true);
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Salió");
        if (collision != null)
        {
            isTrigger = false;
            Msg.SetActive(false);
        }

    }

    public void LoadScene()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Inventory.Instance.spawnCoordinates = newSpawn;

        SceneManager.LoadScene(sceneName);
    }
}
