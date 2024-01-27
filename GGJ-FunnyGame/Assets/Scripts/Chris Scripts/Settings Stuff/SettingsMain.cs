using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMain : MonoBehaviour
{
    public GameObject Settings;
    public GameObject Display;
    public GameObject Connectivity;

    private void Start()
    {
        Settings.SetActive(false);
        Display.SetActive(false);
        Connectivity.SetActive(false);
    }
}
