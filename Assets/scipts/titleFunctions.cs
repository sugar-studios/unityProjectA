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

    public Button editor;

    public Text editorText;

    public Text errorMessage;

    public static string tutorialPath;


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
        editor.interactable = false;
        editorText.fontSize = 9;
        editorText.text = "Finish tutorial to unlock Level Creator";

        tutorialPath = Application.dataPath + "/Saves/tutorial.txt";

        if (!File.Exists(tutorialPath))
        {
            File.WriteAllText(tutorialPath, "0");
        }

        string savedLevels = Application.dataPath + "/Saves/savedLevels.txt";

        if (!File.Exists(savedLevels))
        {
            File.WriteAllText(savedLevels, "");
        }

    }
    private void Update()
    { 
        if (File.ReadAllText(tutorialPath) == "1") { editor.interactable = true; editorText.text = "Level Creator"; editorText.fontSize = 14; }
    }
}

