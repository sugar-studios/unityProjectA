using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 5000f;
    public float sidewaysForce = 50f;
    public bool jumpAvailable = false;

    private Vector3 velocity;

    private bool moving; 

    // Update is called once per tick
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey(KeyBinds.leftKey))
        {
            moving = true;
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); 
        }
        if (Input.GetKey(KeyBinds.rightKey))
        {
            moving = true;
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); 
        }
        if (!Input.GetKey(KeyBinds.rightKey) && !Input.GetKey(KeyBinds.leftKey))
        {
            moving = false;
        }

        if (Input.GetKey(KeyBinds.jumpKey)) 
        {
            if (jumpAvailable == true)
            {
                rb.velocity = new Vector3(rb.velocity.x, 10, rb.velocity.z);
                jumpAvailable = false;
            }       
        } 
        velocity = rb.velocity;
        if (velocity.z > 45)
        {
            velocity.z = 45;
        }
        if (moving == true)
        {
            if (velocity.x > 20)
            {
                velocity.x = 20;
            }
            if (velocity.x < -20)
            {
                velocity.x = -20;
            }
        }
        if (moving == false)
        {
            velocity.x = velocity.x/2 + velocity.x/4;
        }
        

        rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);

    }
}

