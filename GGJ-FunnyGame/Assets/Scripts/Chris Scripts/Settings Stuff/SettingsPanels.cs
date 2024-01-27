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
    public AudioSource musicSource;

    public void Start()
    {
        if (gameObject.name == "Sound")
        {
            musicSource.gameObject.SetActive(true);
        }
    }

    public void Update()
    {
        musicSource.volume = volumeSlider.value/100;
    }

    public void ChangePanels()
    {
        MainPanel.SetActive(true);
        panelOther1.SetActive(false);
        panelOther2.SetActive(false);
    }
}
