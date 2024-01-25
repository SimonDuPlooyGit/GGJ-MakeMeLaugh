using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationUsage : MonoBehaviour
{
    public GameObject appWindow;   

    public void OpenApp()
    {
        appWindow.SetActive(true);
        transform.SetSiblingIndex(7);
    }

    public void CloseApp()
    {
        appWindow.SetActive(false);
    }   
}
