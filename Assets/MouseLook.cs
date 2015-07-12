using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseX;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    public Transform target;

    bool isMouseControled = false;

    float rotationX = 0F;
    float rotationY = 0F;

    void Update()
    {
        /*if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {*/
            //transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            //float newX = gameObject.rigidbody.
        if (axes == RotationAxes.MouseX)
        {
            //float step = 10 * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            //Debug.Log(Input.GetAxis("Mouse X") * sensitivityX);
            if (isMouseControled)
                target.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            //transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }

        
        else
        {
            //float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

           // rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            //rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            if (isMouseControled)
            {
                rotationX += Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                //rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                Debug.Log(Input.GetAxis("Mouse X") * sensitivityX);
                //target.Rotate(rotationY, rotationX, 0);
                target.transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);

            }
                //target.Rotate(Input.GetAxis("Mouse Y") * sensitivityY, Input.GetAxis("Mouse X") * sensitivityX, 0);
            //transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }

        if (target)
            transform.LookAt(target);
    }

    void LateUpdate()

    {
        EventMouseClicked();
        ZoomInOut();
    }

    private void ZoomInOut()
    {
        Camera camera = this.transform.GetComponent<Camera>();
         if (Input.GetAxis("Mouse ScrollWheel") <0)
          {
              if (camera.fieldOfView <= 100)
                  camera.fieldOfView += 2;
              if (camera.orthographicSize <= 20)
                  camera.orthographicSize += 0.5F;
          }
        //Zoom in
         if (Input.GetAxis("Mouse ScrollWheel") > 0)
         {
             if (camera.fieldOfView > 2)
                 camera.fieldOfView -= 2;
             if (camera.orthographicSize >= 1)
                 camera.orthographicSize -= 0.5F;
         } 
    }

    private void EventMouseClicked()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("CLICK");
            isMouseControled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("release");
            isMouseControled = false;
        }
    }


    void Start()
    {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }
}