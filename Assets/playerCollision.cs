using UnityEngine;
using System;

public class playerCollision : MonoBehaviour
{

    public playerMovement movement; 

    public Rigidbody rb; 

    void Start ()
    {
    }
    

    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            Vector3 exploPos= movement.transform.position;
            exploPos.z = exploPos.z + 2;
            rb = movement.rb;
            rb.drag = 0.7f;
            Debug.Log($" player rigid body {rb}");
            Debug.Log($"vector 3 {exploPos}");
            rb.AddExplosionForce(1500, exploPos, 5, 3);
            rb.velocity = new Vector3(Convert.ToInt32(exploPos.x), Convert.ToInt32(exploPos.y), -10);
        }
    }   

}
