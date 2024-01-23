using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchBarStuff : MonoBehaviour
{
    public GameObject brownieRecipe;
    public GameObject growingForAll;

    public TMP_Dropdown dropdown;

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        brownieRecipe.SetActive(false);
        growingForAll.SetActive(false);
    }

    public void SearchBarOptions(int value)
    {
        if (value == 0)
        {
            
        }

        if (value == 1)
        {
            brownieRecipe.SetActive(true);
        }

        if (value == 2)
        {
            growingForAll.SetActive(true);
        }
    }

    public void ExitWebsite()
    {
        brownieRecipe.SetActive(false);
        growingForAll.SetActive(false);
    }
}
