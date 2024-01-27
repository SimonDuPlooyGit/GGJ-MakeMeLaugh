using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Robot : MonoBehaviour
{
    public FindCats findCatsScript;

    public GameObject Robot1;
    public GameObject Robot2;
    public GameObject Robot3;
    public GameObject Robot4;

    public GameObject Download;

    public Toggle Robot1Toggle;

    public Toggle Yes;
    public Toggle No;

    private void Update()
    {
        if (Robot1Toggle.isOn)
        {
            Robot1.SetActive(false);
            Robot2.SetActive(true);
        }

        Robot1Toggle.isOn = false;

        if (findCatsScript.catsFound == 8)
        {
            Robot3.SetActive(false);
            Robot4.SetActive(true);
        }

        if (Yes.isOn)
        {
            Download.SetActive(true);
            Robot4.SetActive(false);
        }
        else if (No.isOn)
        {
            Robot4.SetActive(false);
            Robot1.SetActive(true);

            findCatsScript.catsFound = 0;
        }

        No.isOn = false;
    }

    public void RobotTwoButt1()
    {
        Robot2.SetActive(false);
        Robot3.SetActive(true);
    }

    public void RobotTwoButt2and3()
    {
        Robot1.SetActive(true);
        Robot2.SetActive(false);
    }
}
