using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignIn : MonoBehaviour
{
    public TMP_InputField names;
    public TMP_InputField email;

    public bool download;

    private void Update()
    {
        string nameInput = names.text;
        string emailInput = email.text;

        if (!string.IsNullOrWhiteSpace(nameInput) && !string.IsNullOrWhiteSpace(emailInput))
        {
            download = true;
        }
        else
        {
            download = false;
        }
    }

    public void DownloadRecipe()
    {
        if (download == true)
        {

        }
        else
        {

        }
    }
}
