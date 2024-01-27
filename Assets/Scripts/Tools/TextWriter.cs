using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    private TextMeshProUGUI uiText;
    private string textToWrite = "";
    private int characterIndex = 1;
    private float timePerCharacter;
    private float timer;

    private bool isWriting = false;
    public bool IsWriting => isWriting;

    public void AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        characterIndex = 0;
        isWriting = true;
    }

    private void Update()
    {
        if(uiText != null && isWriting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                //Display next character
                timer += timePerCharacter;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);
            }
        }

        if (characterIndex > textToWrite.Length) { isWriting = false; }
    }
}
