using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneFlying : MonoBehaviour
{
    public Canvas canvas;
    public float desiredDistance;
    public float proximityThreshold;
    public float chaseDuration;
    private float timer;

    private void Start()
    {
        StartTimer();
    }

    void Update()
    {
        Vector2 canvasMousePosition = GetCanvasMousePosition();
        Debug.Log("Canvas Mouse Position: " + canvasMousePosition);

        // Calculate the vector from this object to the target object
        Vector2 toTarget = canvasMousePosition - new Vector2(transform.position.x, transform.position.y);

        // Calculate the current distance between the objects
        float currentDistance = toTarget.magnitude;

        if (currentDistance < proximityThreshold)
        {

            if (timer > 0)
            {
                timer -= Time.deltaTime;

                desiredDistance -= Time.deltaTime * (desiredDistance/chaseDuration);
            }

            // Calculate the desired position to move away from the cursor
            Vector3 desiredPosition = canvasMousePosition - toTarget.normalized * desiredDistance;

            // Move towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        }
    }

    Vector2 GetCanvasMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        {
            return new Vector2(
                mousePosition.x / Screen.width * canvas.pixelRect.width,
                mousePosition.y / Screen.height * canvas.pixelRect.height
            );
        }
    }
    public void StartTimer()
    {
        timer = chaseDuration;
    }

}
