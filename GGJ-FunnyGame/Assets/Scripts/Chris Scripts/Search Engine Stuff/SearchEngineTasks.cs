using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEngineTasks : MonoBehaviour
{
    public int ExitButtons = 0;

    public GameObject Email;
    public GameObject BrownieRecipe;
    public GameObject NoNewsText;

    private void Update()
    {
        if (ExitButtons == 5)
        {
            EmailandRecipe();
        }
    }

    private void EmailandRecipe()
    {
        Email.SetActive(true);
        BrownieRecipe.SetActive(true);
        NoNewsText.SetActive(false);
    }
}
