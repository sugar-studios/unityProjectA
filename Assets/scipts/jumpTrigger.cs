using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTrigger : MonoBehaviour
{
   public GameObject jump;

   private void OnTriggerEnter()
    {
        playerMovement.jumpAvailable = true;
        Debug.Log("DESTROY");
        Destroy(jump);
    }
}
