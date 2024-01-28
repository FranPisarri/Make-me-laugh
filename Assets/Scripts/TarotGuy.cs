using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;




public class TarotGuy : MonoBehaviour
{

    public string[] dialogos1;
    public string[] dialogos2;
    public string[] dialogos3;
    private int dialogIndex;
    private bool dialogFinish = false;
    public TextMeshProUGUI textMesh;
    public GameObject pj;
    private int cardQuantity;


    [SerializeField] private TextWriter _textWriter;


    void Start()
    {
        dialogIndex = 0;
        _textWriter.AddWriter(textMesh, dialogos1[dialogIndex], 0.1f);
        cardQuantity = 0;

    }


    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && !_textWriter.IsWriting)
        {
            for (int i = 0; i < Inventory.Instance.cards.Length; i++)
            {
                if (Inventory.Instance.cards[i])
                {
                    cardQuantity++;
                }
            }
            if (cardQuantity < Inventory.Instance.cards.Length)
            {

                dialogIndex++;
                if (!dialogFinish)
                {
                    if (dialogIndex < dialogos1.Length) { UpdateDialog(dialogIndex, dialogos1); }
                    else
                    {
                        pj.GetComponent<Movement_Player>().enabled = true;
                        gameObject.SetActive(false);
                        dialogIndex = 0;
                        dialogFinish = true;
                    }
                }
                else
                {
                    if (dialogIndex < dialogos2.Length)
                    {
                        string newDialogue;
                        newDialogue = dialogos2[dialogIndex];
                        if (dialogIndex == 1)
                        {
                            newDialogue = dialogos2[dialogIndex] + cardQuantity.ToString() + " of the 10 cards.";

                        }
                        UpdateDialog(newDialogue);
                    }
                    else
                    {
                        pj.GetComponent<Movement_Player>().enabled = true;
                        gameObject.SetActive(false);
                        dialogIndex = 0;
                    }
                }
                cardQuantity = 0;
            }
            else
            {
                Inventory.Instance.misionCheck[3] = true;
                if (dialogIndex < dialogos3.Length) { UpdateDialog(dialogIndex, dialogos3); }
                else
                {
                    Inventory.Instance.FinishGame();
                    pj.GetComponent<Movement_Player>().enabled = true;
                    gameObject.SetActive(false);
                }
                dialogIndex++;
            }

        }
    }

    private void UpdateDialog(int x, string[] dialogos)
    {

        _textWriter.AddWriter(textMesh, dialogos[x], 0.1f);
    }

    private void UpdateDialog(string newDialogue)
    {
        _textWriter.AddWriter(textMesh, newDialogue, 0.1f);
    }
}
