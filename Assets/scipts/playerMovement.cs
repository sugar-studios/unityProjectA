using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.VisualScripting.Member;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 5000f;
    public float sidewaysForce = 75;
    public static bool jumpAvailable = false;
    public static bool fallAvailable = false;
    public static bool dashAvailable = false;
    public static bool holdingDash = false;
    private Vector3 NewPosition;
    private Vector3 PreviousPosition;
    public ParticleSystem cloudBurst;

    private Vector3 velocity;

    private bool moving;

    #region checkSpeed
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
    #endregion

    #region DashParticles
    private void CloudParticles(Vector3 rotation, ParticleSystem clouds)
    {      
        clouds.transform.eulerAngles = rotation;
        clouds.transform.position = this.transform.position;
        clouds.Play();
        clouds.transform.position = this.transform.position;
    }
    #endregion

    #region Dash
    private void Dash(int dashDirection)
    {
        dashAvailable = false;
        
        PreviousPosition = transform.position;
        NewPosition = PreviousPosition;
        NewPosition.x = 5 * dashDirection;

        //raycast check
        RaycastHit hit;
        Vector3 fromPosition = PreviousPosition;
        Vector3 toPosition = NewPosition;
        Vector3 direction = toPosition - fromPosition;
        if (Physics.Raycast(PreviousPosition, direction, out hit))
        {
            if (hit.collider.gameObject.tag == "Obstacle")
            {
                FindObjectOfType<playerCollision>().killPlayer();
            }
        }


        transform.position = NewPosition;
        

    }
    #endregion

    #region SatusReset
    private void Start()
    {
        jumpAvailable = false;
        fallAvailable = false;
        dashAvailable = false;
        holdingDash = false;
    }
    #endregion

    #region KeyOveride
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            KeyBinds.downKey = KeyCode.S;
            KeyBinds.rightKey = KeyCode.D;
            KeyBinds.leftKey = KeyCode.A;
            KeyBinds.jumpKey = KeyCode.Space;
            KeyBinds.dashKey = KeyCode.LeftShift;
        }
    }
    #endregion

    #region MainLoop
    void FixedUpdate()
    {
        velocity = rb.velocity;

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        checkSpeed(rb);
        #region move right 
        if (Input.GetKey(KeyBinds.leftKey))
        {
            moving = true;
            if (velocity.x > -1)
            {
                velocity.x = velocity.x / 16;
                rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
            }
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        #endregion

        #region move left
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
        #endregion

        #region not-moving
        if (!Input.GetKey(KeyBinds.rightKey) && !Input.GetKey(KeyBinds.leftKey))
        {
            moving = false;
        }
        #endregion

        #region jump
        if (Input.GetKey(KeyBinds.jumpKey))
        {
            if (jumpAvailable == true)
            {
                jumpAvailable = false;
                rb.AddForce(0, 500 * Time.deltaTime, 0, ForceMode.VelocityChange);
            }
        }
        if (Input.GetKey(KeyBinds.jumpKey))
        {
            if (jumpAvailable == true)
            {
                jumpAvailable = false;
                rb.AddForce(0, 500 * Time.deltaTime, 0, ForceMode.VelocityChange);
            }
        }
        #endregion

        #region fall
        if (Input.GetKey(KeyBinds.downKey))
        {
            if (fallAvailable == true)
            {
                fallAvailable = false;
                if (Physics.Raycast(transform.position, Vector3.down, out var hit))
                {
                    CloudParticles(new Vector3(-90, 0, 0), cloudBurst);
                    ParticleSystem.EmissionModule em = cloudBurst.emission;
                    em.enabled = true;
                    transform.position = hit.point;
                }
            }
        }
        #endregion

        #region dash
        if (Input.GetKey(KeyBinds.dashKey))
        {
            if (dashAvailable == true)
            {
                if (holdingDash == false)
                {

                    GetComponent<Renderer>().material.color = new Color32(240, 40, 40, 1);
                    if (Input.GetKey(KeyBinds.leftKey))
                    {
                        CloudParticles(new Vector3(-180, 0, 0), cloudBurst);
                        Dash(-1);
                        if (Input.GetKey(KeyBinds.leftKey))
                        {
                            holdingDash = true;
                        }
                    }

                    if (Input.GetKey(KeyBinds.rightKey))
                    {
                        CloudParticles(new Vector3(-180, 0, 0), cloudBurst);
                        Dash(1);
                        if (Input.GetKey(KeyBinds.rightKey))
                        {
                            holdingDash = true;
                        }
                    }
                }
            }
        } else
        {
            GetComponent<MeshRenderer>().material.color = new Color32(197, 49, 49, 1);
        }

        if (holdingDash) 
        {
            if (Input.GetKey(KeyBinds.rightKey) || Input.GetKey(KeyBinds.leftKey))
            {
                holdingDash = true;
            }
            else 
            {
                holdingDash = false;
            }
        }
        #endregion



        checkSpeed(rb);

    }
}
#endregion

