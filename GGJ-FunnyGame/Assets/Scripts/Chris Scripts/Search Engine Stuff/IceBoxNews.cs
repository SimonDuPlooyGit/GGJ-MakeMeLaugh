using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBoxNews : MonoBehaviour
{
    public GameObject mainWindow;
    public GameObject otherWindow_1;
    public GameObject otherWindow_2;
    public GameObject otherWindow_3;
    public GameObject otherWindow_4;
    public GameObject otherWindow_5;
    public GameObject otherWindow_6;

    public void OpenWindow()
    {
        mainWindow.SetActive(true);
        otherWindow_1.SetActive(false);
        otherWindow_2.SetActive(false);
        otherWindow_3.SetActive(false);
        otherWindow_4.SetActive(false);
        otherWindow_5.SetActive(false);
        otherWindow_6.SetActive(false);
    }
}
