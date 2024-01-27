using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class MovingObjectsZ : MonoBehaviour
{
    public GameObject gameManager;
    public float leftClamp;
    public float rightClamp;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && gameManager.GetComponent<RayObjectChecking>().currentObject == gameObject.name && Input.GetMouseButton(0))
        {
            Debug.Log(hit.point);
            // Ensure the z value is within the clamp range
            float clampedZ = Mathf.Clamp(hit.point.z, leftClamp, rightClamp);

            // Set the object's position
            Vector3 rayMovement = new Vector3(transform.position.x, transform.position.y, clampedZ);
            transform.position = rayMovement;
        }
    }
}
