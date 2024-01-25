using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayObjectChecking : MonoBehaviour
{
    public string currentObject;

    void Start()
    {
        
    }

    void Update()
    {
        // Create a ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Declare a RaycastHit variable to store information about the hit
        RaycastHit hit;

        // Check if the ray hits something
        if (Physics.Raycast(ray, out hit))
        {
            // Get the name of the object that was hit
            currentObject = hit.collider.gameObject.name;
            //Debug.Log("Hit object: " + hit.transform.name);

            // You can also do other things with the hit information, for example:
            // hit.transform.position - position of the object that was hit
            // hit.point - point in world space where the ray hit the collider
            // hit.normal - normal vector at the hit point
        }
    }
}
