using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PrinterHittingScript : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject paper;

    public bool printerWorking;

    public int numberOfTimesJammed;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        printerWorking = false;
        numberOfTimesJammed = 0;
    }

    void Update()
    {
        if (numberOfTimesJammed == 5)
        {
            paper.SetActive(true);
            printerWorking = true;
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        numberOfTimesJammed++;
    }
}
