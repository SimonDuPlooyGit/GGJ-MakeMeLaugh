using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperMoving : MonoBehaviour
{
    private float reachDistance;
    public GameObject printer;
    Vector2 distanceVec;

    public void Start()
    {
        distanceVec = Camera.main.transform.position - printer.transform.position;
        reachDistance = distanceVec.magnitude;
    }

    void Update()
    {
        Vector3 cameraRotation = Camera.main.transform.rotation.eulerAngles;

        gameObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * reachDistance;

        Quaternion newRotation = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.up);
        gameObject.transform.rotation = newRotation;

        if (cameraRotation.y == 90)
        {
            reachDistance = distanceVec.magnitude;
        } else
        {
            reachDistance = 1;
        }
    }
}
