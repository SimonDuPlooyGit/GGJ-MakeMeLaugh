using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCats : MonoBehaviour
{
    public int catsFound;

    public Robot robotScript;

    public void FindCatos()
    {
        catsFound += 1;
    }

    public void Turtle()
    {
        catsFound = 0;
        robotScript.Robot3.SetActive(false);
        robotScript.Robot1.SetActive(true);
    }
}
