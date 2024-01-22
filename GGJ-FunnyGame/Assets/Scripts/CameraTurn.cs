using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationDuration = 3.0f; // Duration for the rotation
    private Quaternion targetRotation;
    private float elapsedTime = 0f;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateCamera(-90f); // Rotate 90 degrees left
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            RotateCamera(90f); // Rotate 90 degrees right
        }

        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Smoothly interpolate towards the target rotation using Mathf.SmoothStep
        float t = Mathf.SmoothStep(0f, 1.0f, elapsedTime / rotationDuration);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, t);
    }

    void RotateCamera(float angle)
    {
        // Reset the elapsed time when a new rotation is initiated
        elapsedTime = 0f;

        // Calculate the target rotation
        targetRotation *= Quaternion.Euler(0f, angle, 0f);
    }
}


