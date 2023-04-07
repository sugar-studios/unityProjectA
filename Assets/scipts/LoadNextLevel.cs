using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadNextLevel : MonoBehaviour
{
    public void LoadNexLevel()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case ("4"):
                SceneManager.LoadScene(0);
                break;
            default:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
        
    }
}
