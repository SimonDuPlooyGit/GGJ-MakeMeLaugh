using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas UI;
    public Canvas ComputerScreen;

    public GameObject computerPrompt;
    public GameObject routerPrompt;
    public Camera mainCamera;

    public bool routerON;
    public bool inComputer;

    public float zoomSpeed = 0.1f;
    public float targetZoom = 5.0f;

    void Start()
    {
        mainCamera = Camera.main;
        UI.gameObject.SetActive(true);
        ComputerScreen.gameObject.SetActive(false);
        routerON = false;
        inComputer = false;
    }


    void Update()
    {
        if (gameObject.GetComponent<RayObjectChecking>().currentObject == "Computer")
        {
            computerPrompt.gameObject.SetActive(true);
        }
        else { computerPrompt.gameObject.SetActive(false); }

        if (gameObject.GetComponent<RayObjectChecking>().currentObject == "Router")
        {
            routerPrompt.gameObject.SetActive(true);
        }
        else { routerPrompt.gameObject.SetActive(false); }

        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.GetComponent<RayObjectChecking>().currentObject == "Computer")
            {
                goIntoComputer();
            }
        }
    }

    public void goIntoComputer()
    {
        UI.gameObject.SetActive(false);
        StartCoroutine(ZoomCamera());
        ComputerScreen.gameObject.SetActive(true);
    }

    IEnumerator ZoomCamera()
    {
        while (mainCamera.fieldOfView > targetZoom)
        {
            mainCamera.fieldOfView -= zoomSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
