using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 5000f;
    public float sidewaysForce = 75;
    public static bool jumpAvailable = false;

    private Vector3 velocity;

    private bool moving;


    private void checkSpeed(Rigidbody rb)
    {
        velocity = rb.velocity;

        if (velocity.z > 45)
        {
            velocity.z = 45;
        }
        if (velocity.y > 51)
        {
            velocity.y = 50;
        }
        if (moving == true)
        {
            if (velocity.x > 25)
            {
                velocity.x = 25;
            }
            if (velocity.x < -25)
            {
                velocity.x = -25;
            }
        }
        if (moving == false)
        {
            velocity.x = velocity.x / 2 + velocity.x / 4;
        }


        rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            KeyBinds.downKey = KeyCode.S;
            KeyBinds.rightKey = KeyCode.D;
            KeyBinds.leftKey = KeyCode.A;
            KeyBinds.jumpKey = KeyCode.Space;
        }
    }

    // Update is called once per tick
    void FixedUpdate()
    {
        velocity = rb.velocity;

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        checkSpeed(rb);

        if (Input.GetKey(KeyBinds.leftKey))
        {
            moving = true;
            if (velocity.x > -1)
            {
                velocity.x = velocity.x/16;
                rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
            }
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyBinds.rightKey))
        {
            moving = true;
            if (velocity.x < 1)
            {
                velocity.x = velocity.x / 16;
                rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
            }
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
                jumpAvailable = false;
                rb.AddForce(0, 500*Time.deltaTime, 0, ForceMode.VelocityChange);
            }       
        }

        checkSpeed(rb);

    }
}

