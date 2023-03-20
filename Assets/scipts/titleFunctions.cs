using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleFunctions : MonoBehaviour
{
    public GameObject arrowImage;
    public Vector3 arrowPos;


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

