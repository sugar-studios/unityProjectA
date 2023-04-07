using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class titleFunctions : MonoBehaviour
{

    public GameObject MainMenu;

    public GameObject ControlsMenu;

    public Text errorMessage;


    double screenHeight = Screen.height;


    public void StartGame()
    {
        if (KeyBinds.valid)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            errorMessage.text = "There must be conflicting keybinds, fix then try again";
        }
        
    }


    public void GoToControls()
    {
        errorMessage.text = "";
        ControlsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void GoToMain()
    {
        errorMessage.text = "";
        MainMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }


    private void Start() 
    {
        MainMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }
}

