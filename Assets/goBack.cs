using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void GoToMainMenu()
    {
        // Load the scene with the main menu (assuming the main menu scene is named "MainMenu")
        SceneManager.LoadScene("MainMenu");
    }
}
