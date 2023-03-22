using UnityEngine;
using System.Collections;

public class VoidTrigger : MonoBehaviour
{
    public playerCollision playerCollision;

    private void OnTriggerEnter ()
    {
        playerCollision.endGame();
    }    
}