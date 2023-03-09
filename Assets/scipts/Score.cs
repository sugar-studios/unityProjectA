using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player; 
    public float score = 0f;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        //score = player.position.z.ToString();
        score = player.position.z;
        scoreText.text = $"{score.ToString("0")} meters";
    }
}
