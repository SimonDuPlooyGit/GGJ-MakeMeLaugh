using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailWindow : MonoBehaviour
{
    public GameObject Email;
    public GameObject warningMessage;

    public void EmailTab()
    {
        Email.SetActive(true);
        warningMessage.gameObject.SetActive(true);
    }
}
