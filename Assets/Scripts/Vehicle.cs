using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all the vehicles
/// </summary>
public class Vehicle : MonoBehaviour
{
    // If the vehicle is selected
    protected bool isSelected = false;

    // Initial location and rotation of vehicle - can be overriden
    protected virtual Vector3 InitialPosition => Vector3.zero;
    protected virtual Quaternion InitialRotation => Quaternion.identity;

    // Forward vector of the vehicle - can be overriden
    protected virtual Vector3 forwardVector => Vector3.forward;


    // Main camera
    protected GameObject mainCamera;

    // Position and angle of the camera relative to vehicle
    protected virtual Vector3 cameraOffset => new Vector3(0, 3.7f, -5);
    protected virtual Quaternion cameraRotation => Quaternion.Euler(15, 0, 0);

    // Linear speed
    protected virtual float speed => 30.0f;
    protected virtual float turnSpeed => 60.0f;

    // Initialization
    void Start()
    {
    }

    void Update()
    {
    }

    public void Setup()
    {
        // This vehicle is iselected
        isSelected = true;

        // Move the vehicle to its beginning position
        transform.position = InitialPosition + 4 * Vector3.forward;
        transform.rotation = InitialRotation;

        // Attach the camera to the vehicle
        mainCamera = GameObject.FindWithTag("MainCamera");
        mainCamera.transform.parent = transform;
        mainCamera.transform.position = cameraOffset;
        mainCamera.transform.rotation = cameraRotation;

        //Debug.Log("MoveToBeginningOfTrack() " + GetType().ToString());
    }

    protected void Move()
    {
        if (isSelected)
        {
            var forward = Input.GetAxis("Vertical");
            var rotate = Input.GetAxis("Horizontal");

            if (forward != 0)
            {
                //Debug.Log($"fwd {forward} - translate {Time.deltaTime * speed * forward}");
                transform.Translate(forwardVector * Time.deltaTime * speed * forward);
            }

            if (rotate != 0)
            {
                transform.Rotate(0, Time.deltaTime * turnSpeed * rotate, 0);
            }
        }
    }

    private int numCol = 0;
    protected void ProcessCollision(Collider other)
    {
        Debug.Log($"Collision {gameObject.name} {other.gameObject.name} {numCol}");
        if (other.CompareTag("Finish") && ++numCol == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            Debug.Log("Game over");
        }
    }
}
