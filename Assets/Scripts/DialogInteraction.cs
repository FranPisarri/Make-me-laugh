using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogInteraction : MonoBehaviour
{
    public string[] dialogos;
    private int dialogIndex;

    public TextMeshProUGUI textMesh;
    public GameObject pj;

    [SerializeField] private TextWriter _textWriter;

    void Start()
    {
        dialogIndex = 0;
        _textWriter.AddWriter(textMesh, dialogos[dialogIndex], 0.1f);
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && !_textWriter.IsWriting)
        {
            Debug.Log("Sii");
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
        _textWriter.AddWriter(textMesh, dialogos[x], 0.1f);
    }
}
