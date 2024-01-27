using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignIn : MonoBehaviour
{
    public TMP_InputField names;
    public TMP_InputField email;

    public GameObject firstRobot;

    public GameObject RobotPanel;
    public GameObject RecipeSite;

    public bool robot;

    private void Update()
    {
        string nameInput = names.text;
        string emailInput = email.text;

        if (!string.IsNullOrWhiteSpace(nameInput) && !string.IsNullOrWhiteSpace(emailInput))
        {
            robot = true;
            DownloadRecipe();
        }
        else
        {
            robot = false;
        }
    }

    public void DownloadRecipe()
    {
        if (robot == true)
        {
            firstRobot.SetActive(true);
        }
        else
        {

        }
    }

    public void ActivateRobot()
    {
        RobotPanel.SetActive(true);
        RecipeSite.SetActive(false);
    }
}
