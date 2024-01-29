using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class DialogDuck_Cat : MonoBehaviour
{

    public string[] dialogos1;
    public bool[] dialogos2;
    private int dialogIndex;
    public GameObject img1;
    public GameObject img2;

    public TextMeshProUGUI textMesh1;
    public TextMeshProUGUI textMesh2;
    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public GameObject button1;
    public GameObject button2;
    private bool optionsActive = false;
    private int selected = 0;
    public GameObject pj;
    public GameObject duck;
    public GameObject lifeBar;

    [SerializeField] private TextWriter _textWriter;
    void Start()
    {
        dialogIndex = 0;
        img2.SetActive(true);
        img1.SetActive(false);
        textMesh1.text = "";
        UpdateDialog(dialogIndex, dialogos1, textMesh2);


    }

    void Update()
    {
        if (optionsActive)
        {
            float election = Input.GetAxis("Vertical");
            if (election < 0)
            {
                button2.GetComponent<Image>().color = Color.green;
                button1.GetComponent<Image>().color = Color.gray;
                selected = -1;
            }
            if (election > 0)
            {
                button1.GetComponent<Image>().color = Color.green;
                button2.GetComponent<Image>().color = Color.gray;
                selected = 1;
            }
            if (Input.GetKey(KeyCode.Space) && selected != 0)
            {
                button1.SetActive(false);
                button2.SetActive(false);
                option1.text = "";
                option2.text = "";
                optionsActive = false;
                button1.GetComponent<Image>().color = Color.gray;
                button2.GetComponent<Image>().color = Color.gray;
                if (selected == 1)
                {
                    UpdateDialog(dialogIndex, dialogos1, textMesh2);
                }
                if (selected == -1)
                {
                    //Fight
                    duck.GetComponent<CircleCollider2D>().enabled = false;
                    duck.GetComponent<NPCDialogTrigger>().Msg.SetActive(false);
                    
                    pj.GetComponentInChildren<Camera>().orthographicSize = 5;
                    pj.GetComponent<Fight>().enabled = true;
                    lifeBar.SetActive(true);
                    this.gameObject.SetActive(false);
                }
                dialogIndex++;
                selected = 0;
            }
        }
        else if (Input.GetKey(KeyCode.Space) && !_textWriter.IsWriting)
        {
            dialogIndex++;
            //Si ya pase todos los dialogos se cierra:
            if (dialogIndex >= dialogos1.Length)
            {
                pj.GetComponent<Movement_Player>().enabled = true;
                duck.GetComponent<NPCDialogTrigger>().Msg.GetComponent<SpriteRenderer>().enabled = false;
                duck.GetComponent<NPCDialogTrigger>().enabled = false;

                for (int i = 0; i < Inventory.Instance.cards.Length; i++)
                {
                    Inventory.Instance.cards[pj.GetComponent<Fight>().cardNumber] = true;
                }

                gameObject.SetActive(false);
                dialogIndex = 0;
            }
            
            if (dialogos2[dialogIndex])
            {
                img1.SetActive(true);
                img2.SetActive(false);
                textMesh2.text = "";

                if (dialogIndex < dialogos1.Length) { UpdateDialog(dialogIndex, dialogos1, textMesh1); }

            }
            else
            {
                
                img1.SetActive(false);
                img2.SetActive(true);
                textMesh1.text = "";
                button1.SetActive(true);
                button2.SetActive(true);
                option1.text = dialogos1[dialogIndex];
                option2.text = dialogos1[dialogIndex+1];
                optionsActive = true;
                //if (dialogIndex < dialogos1.Length) { UpdateDialog(dialogIndex, dialogos1, textMesh2); }
                
            }
        }
        
    }

    private void UpdateDialog(int x, string[] dialogos, TextMeshProUGUI mesh)
    {

        _textWriter.AddWriter(mesh, dialogos[x], 0.05f);
    }

    private void UpdateDialog(string newDialogue, TextMeshProUGUI mesh)
    {
        _textWriter.AddWriter(mesh, newDialogue, 0.1f);
    }
}
