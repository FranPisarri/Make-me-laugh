using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ClownGetNose : MonoBehaviour
{
    private NPCDialogTrigger trigger;

    public Sprite newClown;
    public Sprite newClownFace;

    public GameObject ClownFace;
    public ItemName keyObject;

    void Start()
    {
        trigger = GetComponent<NPCDialogTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.IsTrigger && Inventory.Instance.keyItems[(int)keyObject])
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = newClown;
                ClownFace.GetComponent<Image>().sprite = newClownFace;

            }
        }
    }
}
