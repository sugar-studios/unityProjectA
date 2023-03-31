using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleFunctions : MonoBehaviour
{

    public GameObject MainMenu;

    public GameObject ControlsMenu;


    double screenHeight = Screen.height;


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void GoToControls()
    {
        ControlsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void GoToMain()
    {
        MainMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }


    private void Start() 
    {
        MainMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }
}

