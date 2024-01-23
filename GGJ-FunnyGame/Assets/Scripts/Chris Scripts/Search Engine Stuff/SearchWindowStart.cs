using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchWindowStart : MonoBehaviour
{
    #region Search Engine Stuff
    public GameObject searchWindow1;
    public GameObject searchWindow2;
    public GameObject searchWindow3;
    public GameObject searchWindow4;
    public GameObject searchWindow5;
    public GameObject searchWindow6;
    #endregion

    private void Start()
    {
        SearchEngineWindows();
    }

    private void SearchEngineWindows()
    {
        searchWindow1.SetActive(true);
        searchWindow2.SetActive(false);
        searchWindow3.SetActive(false);
        searchWindow4.SetActive(false);
        searchWindow5.SetActive(false);
        searchWindow6.SetActive(false);
    }
}
