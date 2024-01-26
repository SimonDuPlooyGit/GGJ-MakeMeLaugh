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
    float halfWidth, halfHeight;

    Vector2 canvasSize;
    private void Start()
    {
        StartTimer();
        canvasSize = canvas.renderingDisplaySize;
        Debug.Log(canvasSize);
        
        halfWidth = canvasSize.x / 2;
        Debug.Log(halfWidth);
        halfHeight = canvasSize.y / 2;
        Debug.Log(halfHeight);
    }

    void Update()
    {
        //Debug.Log(gameObject.GetComponent<RectTransform>().anchoredPosition);
        Vector2 canvasMousePosition = GetCanvasMousePosition();
        //Debug.Log("Canvas Mouse Position: " + canvasMousePosition);

        // Calculate the vector from this object to the target object
        Vector2 toTarget = canvasMousePosition - new Vector2(transform.position.x, transform.position.y);

        // Calculate the current distance between the objects
        float currentDistance = toTarget.magnitude;

        if (currentDistance < proximityThreshold)
        {

            if (timer > 0)
            {
                timer -= Time.deltaTime;

                desiredDistance -= Time.deltaTime * (desiredDistance / chaseDuration);
                proximityThreshold -= Time.deltaTime * (proximityThreshold / chaseDuration);

            } else if (timer <= 0)
            {
                desiredDistance = 0f;
                proximityThreshold = 0f;
            }

            // Calculate the desired position to move away from the cursor
            Vector3 desiredPosition = canvasMousePosition - toTarget.normalized * desiredDistance;
            float clampedXAnchor = Mathf.Clamp(gameObject.GetComponent<RectTransform>().anchoredPosition.x, -halfWidth, halfWidth);
            float clampedYAnchor = Mathf.Clamp(gameObject.GetComponent<RectTransform>().anchoredPosition.y, -halfHeight, halfHeight);

            if (clampedXAnchor > -halfWidth && clampedXAnchor < halfWidth && clampedYAnchor > -halfHeight && clampedYAnchor < halfHeight)
            {
                transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 2);
            }
            else 
            {
                transform.position = Vector3.Lerp(transform.position, canvas.transform.position, Time.deltaTime * 4);
            }
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
    private void StartTimer()
    {
        timer = chaseDuration;
    }
}
