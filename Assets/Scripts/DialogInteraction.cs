using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogInteraction : MonoBehaviour
{
    public string[] dialogos;
    private int dialogIndex;
    private float timer;

    public TextMeshProUGUI textMesh;
    public GameObject pj;
    void Start()
    {
        dialogIndex = 0;
        timer = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timer > 2)
        {
            Debug.Log("Sii");
            timer = 0;
            dialogIndex++;
            if (dialogIndex < dialogos.Length) { UpdateDialog(dialogIndex); }
            else
            {
                pj.GetComponent<Movement_Player>().enabled = true;
                gameObject.SetActive(false);
            }
        }
    }

    private void UpdateDialog(int x)
    {
        textMesh.text = dialogos[x];
    }
}
