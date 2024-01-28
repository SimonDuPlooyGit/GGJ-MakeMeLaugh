using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToPrinter : MonoBehaviour
{
    public GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    public void sendToPrint()
    {
        gameManager.GetComponent<GameManager>().imageSentToPrint = true;

        
    }
}
