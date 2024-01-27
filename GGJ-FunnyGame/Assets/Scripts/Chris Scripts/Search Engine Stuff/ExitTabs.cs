using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTabs : MonoBehaviour
{
    public GameObject Tab;

    public GameObject Window;

    public GameObject otherWindow;
    public GameObject otherWindow2;

    private void Start()
    {
        Tab.SetActive(false);
    }

    public void ExitTab()
    {
        Tab.SetActive(false);
    }

    public void EnterTab()
    {
        Window.SetActive(true);
        otherWindow.SetActive(false);
        otherWindow2.SetActive(false);
    }
}
