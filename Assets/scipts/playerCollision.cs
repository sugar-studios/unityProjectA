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
        rb.constraints = RigidbodyConstraints.None;
        rb.drag = 0.7f;
        rb.AddExplosionForce(1500, exploPos, 5, 3);
        rb.velocity = new Vector3(Convert.ToInt32(exploPos.x), Convert.ToInt32(exploPos.y), -10);
    }
    public void killPlayer()
    {
        movement.enabled = false;
        pushBackPlayer();
        FindObjectOfType<GameManger>().EndGame();
    }


    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {

            killPlayer();            
        }
    }   
    public void endGame()
    {
        rb.drag = 0.7f;
        movement.enabled = false;
        FindObjectOfType<GameManger>().EndGame();        
    }
}
