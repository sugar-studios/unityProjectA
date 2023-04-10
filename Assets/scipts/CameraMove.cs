using UnityEngine;
using UnityEngine.UI;


public class CameraMove : MonoBehaviour
{

    private float xAxis;
    private float yAxis;
    private float zAxis;
    private float yRot = 0;
    private float zoom;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {   
     
        if (Input.GetKey(KeyCode.A))
        {
            xAxis = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xAxis = 1;
        } else
        { 
            xAxis = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            yAxis = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            yAxis = -1;
        } else 
        {
            yAxis = 0;        
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            zAxis = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            zAxis = -1;
        }
        else
        {
            zAxis = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            yRot += 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            yRot -= 1;
        }


        zoom = Input.GetAxis("Mouse ScrollWheel") * 10;

        // move camera based on info from xAxis and yAxis
        transform.Translate(new Vector3(xAxis/15, yAxis/15, zAxis/15));
        transform.eulerAngles = new Vector3(0, yRot/5, 0);



        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -20, 20),
            Mathf.Clamp(transform.position.y, 1, 15),
            Mathf.Clamp(transform.position.z, -20, 400));

       if (zoom < 0 && cam.orthographicSize >= -25)
            cam.orthographicSize -= zoom * -1;

       if (zoom > 0 && cam.orthographicSize <= -5)
            cam.orthographicSize += zoom * 1;
   
    }
}