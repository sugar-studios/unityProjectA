using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 50000f;
    public float sidewaysForce = 100f;

    // Start is called before the first tick update
    void Start()
    {
        rb.AddForce(11250 * Time.deltaTime, 0, 0);
        rb.AddForce(25000 * Time.deltaTime, 0, 0);
        forwardForce = 50000f;
    }

    // Update is called once per tick
    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); 
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); 
        }
    }
}

