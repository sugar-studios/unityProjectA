using UnityEngine;
using System;

public class playerCollision : MonoBehaviour
{

    public playerMovement movement; 
    public Rigidbody rb; 


    void pushBackPlayer() 
    {
        Vector3 exploPos= movement.transform.position;
        exploPos.z = exploPos.z + 2;
        rb = movement.rb;
        rb.drag = 0.7f;
        rb.AddExplosionForce(1500, exploPos, 5, 3);
        rb.velocity = new Vector3(Convert.ToInt32(exploPos.x), Convert.ToInt32(exploPos.y), -10);
    }


    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            pushBackPlayer();
            FindObjectOfType<GameManger>().EndGame();
            
        }
    }   


    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            rb = movement.GetComponent<Rigidbody>();
            rb = movement.rb;
            rb.drag = 1;
            rb.AddForce(0, -5000 * Time.deltaTime, 0);
            movement.enabled = false;
            FindObjectOfType<GameManger>().EndGame();
        }
    }

}
