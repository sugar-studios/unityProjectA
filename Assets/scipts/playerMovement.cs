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

        if (Input.GetKey(KeyBinds.leftKey))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); 
        }
        if (Input.GetKey(KeyBinds.rightKey))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); 
        }
        if (Input.GetKey(KeyBinds.jumpKey)) 
        {
            if (jumpAvailable == true)
            {
                Debug.Log("JUMP");
                rb.AddForce(0, 50000 * Time.deltaTime, 0);
                jumpAvailable = false;
            }
                
        }        
    }
}

