using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleFunctions : MonoBehaviour
{
    public GameObject arrowImage;
    public Vector3 arrowPos;
    public static KeyCode KeyRight =  KeyCode.A;
    public static KeyCode KeyLeft =  KeyCode.D;
    public static KeyCode KeyDown =  KeyCode.S;
    public static KeyCode KeyJump =  KeyCode.Space;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        if (mousePos.y > 222f)
        {
            arrowPos = arrowImage.transform.position;
            arrowPos.y = 290;
            arrowImage.transform.position = new Vector3(arrowPos.x, arrowPos.y, arrowPos.z);
        }
        else
        {
            arrowPos = arrowImage.transform.position;
            arrowPos.y = 235;
            arrowImage.transform.position = new Vector3(arrowPos.x, arrowPos.y, arrowPos.z);
        }
    }
}

