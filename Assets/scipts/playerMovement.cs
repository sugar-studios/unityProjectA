using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 50000f;
    public float sidewaysForce = 100f;
    public bool jumpAvailable = false;

    // Update is called once per tick
    void FixedUpdate()
    {
        forwardForce = 50000f;
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); 
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); 
        }
        if (jumpAvailable && Input.GetKey(KeyCode.Space)) 
        {
            jumpAvailable = false;
            rb.AddForce(0, 200 * Time.deltaTime, 0);
        }        
    }
}

