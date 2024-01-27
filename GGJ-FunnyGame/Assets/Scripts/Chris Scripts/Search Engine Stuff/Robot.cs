using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Robot : MonoBehaviour
{
    public GameObject Robot1;
    public GameObject Robot2;
    public GameObject Robot3;
    public GameObject Robot4;

    public Toggle Robot1Toggle;

    public TMP_InputField numberAnswer;

    private void Update()
    {
        if (Robot1Toggle.isOn)
        {
            Robot1.SetActive(false);
            Robot2.SetActive(true);
        }
        else
        {

        }

        string number = numberAnswer.text;
    }
}
