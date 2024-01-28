using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneClicking : MonoBehaviour
{
    public GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    public void SendEmail()
    {
        gameManager.GetComponent<GameManager>().emailSent = true;
    }
}
