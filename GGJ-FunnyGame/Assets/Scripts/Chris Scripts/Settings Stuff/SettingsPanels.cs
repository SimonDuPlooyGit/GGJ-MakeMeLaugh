using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanels : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject panelOther1;
    public GameObject panelOther2;

    public void ChangePanels()
    {
        MainPanel.SetActive(true);
        panelOther1.SetActive(false);
        panelOther2.SetActive(false);
    }
}
