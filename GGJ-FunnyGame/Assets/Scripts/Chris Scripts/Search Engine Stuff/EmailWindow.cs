using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailWindow : MonoBehaviour
{
    public GameObject Email;
    public GameObject Window;
    public GameObject warningMessage;

    public void EmailTab()
    {
        Email.SetActive(true);
        Window.SetActive(true);
        warningMessage.gameObject.SetActive(true);

        DialogueManager.instance.enterDialogueMode(Resources.Load<TextAsset>("DialogueTXTs/GrannyDialogue"));
    }
}
