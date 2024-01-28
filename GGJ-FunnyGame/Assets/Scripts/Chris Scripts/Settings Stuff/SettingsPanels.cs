using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanels : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject panelOther1;
    public GameObject panelOther2;
    public Slider volumeSlider;
    public AudioSource gameMusic;


    public void Start()
    {
    }

    public void Update()
    {
        gameMusic.volume = volumeSlider.value/1000;
        
    }

    public void ChangePanels()
    {
        MainPanel.SetActive(true);
        panelOther1.SetActive(false);
        panelOther2.SetActive(false);
    }

    public void submitSound()
    {
        if (volumeSlider.value == 100)
        {
            volumeSlider.interactable = false;
            DialogueManager.instance.enterDialogueMode(Resources.Load<TextAsset>("DialogueTXTs/GrannyDialogue"));
            
            gameObject.SetActive(false);
        }
    }
}
