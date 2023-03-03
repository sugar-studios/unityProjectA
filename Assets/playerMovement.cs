using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 1000f;
    public float sidewaysForce = 3000f;

    // Start is called before the first tick update
    void Start()
    {
        //rb.AddForce(0, 200, 500);
    }

    // Update is called once per tick
    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0); 
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0); 
        }
    }
}

