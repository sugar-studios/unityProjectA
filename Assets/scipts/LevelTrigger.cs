using UnityEngine;
using System.Collections;

public class LevelTrigger : MonoBehaviour
{
    public GameManger gameManger;

    private void OnTriggerEnter ()
    {
        gameManger.NextLevel();
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
    
}
