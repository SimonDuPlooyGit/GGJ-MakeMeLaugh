using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFiles : MonoBehaviour
{
    public GameObject mainFile;
    public GameObject FiletoOpen;

    public void OpenNext()
    {
        mainFile.SetActive(false);
        FiletoOpen.SetActive(true);
    }
}
