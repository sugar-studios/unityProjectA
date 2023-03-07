using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject nextLevelUI;

    void Start()
    {
        nextLevelUI.SetActive(false);
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
        nextLevelUI.SetActive(true);
    }
}
