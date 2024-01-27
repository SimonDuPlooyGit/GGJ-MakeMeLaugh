using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFileLocation : MonoBehaviour
{
    public GameObject Location;

    public GameObject otherLocation0;

    public void OpenLocation()
    {
        Location.SetActive(true);
        otherLocation0.SetActive(false);
    }
}
