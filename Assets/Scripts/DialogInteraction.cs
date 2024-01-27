using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum ItemName
{
    clownNose, lostBoy, item3
}

public class DialogInteraction : MonoBehaviour
{
    public string[] dialogos1;
    public string[] dialogos2;
    private int dialogIndex;

    public TextMeshProUGUI textMesh;
    public GameObject pj;
    public ItemName keyObject;
    

    [SerializeField] private TextWriter _textWriter;


    void Start()
    {
        dialogIndex = 0;
        _textWriter.AddWriter(textMesh, dialogos1[dialogIndex], 0.1f);
        
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && !_textWriter.IsWriting)
        {
            //Debug.Log("Sii");
            //Debug.Log(Inventory.Instance.keyItems[(int)keyObject]);
            if (!Inventory.Instance.keyItems[(int)keyObject])
            {
                dialogIndex++;
                if (dialogIndex < dialogos1.Length) { UpdateDialog(dialogIndex, dialogos1); }
                else
                {
                    pj.GetComponent<Movement_Player>().enabled = true;
                    gameObject.SetActive(false);
                    dialogIndex = 0;
                }
            }
            else
            {
                if (dialogIndex < dialogos2.Length) { UpdateDialog(dialogIndex, dialogos2); }
                else
                {
                    pj.GetComponent<Movement_Player>().enabled = true;
                    gameObject.SetActive(false);
                }
                dialogIndex++;
            }
            
        }
    }

    private void UpdateDialog(int x, string[]  dialogos)
    {
        _textWriter.AddWriter(textMesh, dialogos[x], 0.1f);
    }
}


