using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationUsage : MonoBehaviour
{
    public GameObject appWindow;

    #region Search Engine Stuff
    public GameObject searchWindow1;
    public GameObject searchWindow2;
    public GameObject searchWindow3;
    public GameObject searchWindow4;
    public GameObject searchWindow5;
    public GameObject searchWindow6;
    #endregion

    private void Start()
    {
        SearchEngineWindows();
    }

    public void OpenApp()
    {
        appWindow.SetActive(true);
    }

    public void CloseApp()
    {
        appWindow.SetActive(false);
    }

    private void SearchEngineWindows()
    {
        searchWindow1.SetActive(true);
        searchWindow2.SetActive(false);
        searchWindow3.SetActive(false);
        searchWindow4.SetActive(false);
        searchWindow5.SetActive(false);
        searchWindow6.SetActive(false);
    }
}
