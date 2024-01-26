using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class HitByRay : MonoBehaviour
{
    public bool keyItem;

    public GameObject highlight;
    public GameObject gameManager;
    public GameObject ON;
    public GameObject OFF;


    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        if (keyItem && gameManager.GetComponent<RayObjectChecking>().currentObject == gameObject.name)
        {
            highlight.SetActive(true);

            if (gameObject.name == "Router")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    turnOnRouter();
                }
            } else if (gameObject.name == "ReamOfPaper")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RemovePaper();
                }
            }
        }
        else { highlight.SetActive(false);}
    }

    public void turnOnRouter()
    {
        ON.SetActive(true);
        OFF.SetActive(false);

        gameManager.GetComponent<GameManager>().routerON = true;
    }

    public void RemovePaper()
    {
        gameManager.GetComponent<GameManager>().paperTaken = true;
        gameObject.SetActive(false);
    }
}
