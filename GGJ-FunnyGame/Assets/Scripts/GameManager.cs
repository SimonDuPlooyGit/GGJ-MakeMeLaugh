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

    public float zoomSpeed;
    public float targetZoom;
    public float defaultZoom;

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitComputer();
        }
    }

    public void goIntoComputer()
    {
        UI.gameObject.SetActive(false);
        StartCoroutine(ZoomInCamera());
    }

    public void exitComputer()
    {
        UI.gameObject.SetActive(true);
        StartCoroutine(ZoomOutCamera());
    }

    IEnumerator ZoomInCamera()
    {
        while (mainCamera.fieldOfView > targetZoom)
        {
            mainCamera.fieldOfView -= zoomSpeed * Time.deltaTime;
            yield return null;
        }
        ComputerScreen.gameObject.SetActive(true);
    }
    
    IEnumerator ZoomOutCamera()
    {
        ComputerScreen.gameObject.SetActive(false);

        while (mainCamera.fieldOfView < defaultZoom)
        {
            mainCamera.fieldOfView += zoomSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
