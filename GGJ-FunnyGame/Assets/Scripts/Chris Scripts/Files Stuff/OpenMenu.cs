using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject recipe;

    public bool SentToPrinter;

    private void Start()
    {
        SentToPrinter = false;
    }

    public void OpenMenuPop()
    {
        menu.SetActive(true);
    }

    public void CloseMenuPop()
    {
        menu.SetActive(false);
    }

    public void SendToPrinter()
    {
        SentToPrinter = true;
        menu.SetActive(false);
    }

    public void DownloadRecipe()
    {
        recipe.SetActive(true);
    }
}
