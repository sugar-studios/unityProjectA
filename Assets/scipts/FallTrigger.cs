using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public GameObject fall;

    private void OnTriggerEnter()
    {
        playerMovement.fallAvailable = true;
        Debug.Log("DESTROY");
        Debug.Log(playerMovement.fallAvailable);
        Destroy(fall);
    }
}