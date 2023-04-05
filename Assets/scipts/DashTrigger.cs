using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTrigger : MonoBehaviour
{
    public GameObject dash;

    private void OnTriggerEnter()
    {
        playerMovement.dashAvailable = true;
        Debug.Log("DESTROY");
        Debug.Log(playerMovement.dashAvailable);
        Destroy(dash);
    }
}
