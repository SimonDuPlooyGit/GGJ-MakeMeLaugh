using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueBTN : MonoBehaviour
{
    [SerializeField] private TextAsset grannyJSON;

    public void startInter()
    {
        DialogueManager.instance.enterDialogueMode(grannyJSON);
    }

    public void next()
    {
        DialogueManager.instance.continueStory();
    }
}
