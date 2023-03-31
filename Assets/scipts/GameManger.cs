using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameManger : MonoBehaviour
{
    public playerMovement movement; 
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject nextLevelUI;
    string left = KeyBinds.leftKey.ToString();
    string right = KeyBinds.rightKey.ToString();
    string jump = KeyBinds.jumpKey.ToString();
    string down = KeyBinds.downKey.ToString();
    public TMP_Text TutorialText;

    void Start()
    {
        nextLevelUI.SetActive(false);

        switch (SceneManager.GetActiveScene().name)
        {
            case ("1"):
                TutorialText.text = "Use the " + left + " and " + right + " keys to dodge cubes";
                break;
            case ("3"):
                TutorialText.text = "After collecting a jump orb, use the " + jump + " key to jump short cubes";
                break;
            case ("4"):
                TutorialText.text = "After collecting a fall orb, use the " + down + " key to fastfall whilst midair";
                break;
            case ("5"):
                TutorialText.text = "Here we go!";
                break;
            default:
                TutorialText.text = "";
                break;
        }
    }
    

    public void EndGame()
    {
        if (!gameHasEnded)
        {
        gameHasEnded = true;
        Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        movement.enabled = false;
        nextLevelUI.SetActive(true);
        
    }
}
