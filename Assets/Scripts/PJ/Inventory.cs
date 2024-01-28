using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Inventory.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public bool[] cards;
    public bool[] keyItems;

    public Vector3 spawnCoordinates;

    public bool[] misionCheck;

    public void FinishGame()
    {
        bool finishGame = true;
        for(int i = 0; i < misionCheck.Length; i++)
        {
            if (!misionCheck[i]) { finishGame = false; break; }
        }

        if (finishGame)
        {
            SceneManager.LoadScene("EndingScene");
        }
    }



}
