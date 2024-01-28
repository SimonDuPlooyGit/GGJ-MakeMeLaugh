using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJumps : MonoBehaviour
{
    SearchEngineTasks searchEngineTasksScript;

    private RectTransform rectTransform;

    private float maxVerticalPos = 445;
    private float minVerticalPos = -370;
    private float maxHorizontalPos = 860;
    private float minHorizontalPos = -860;

    private Vector2 position;

    private int Clicks;
    private int ExitButtons;

    public GameObject window;
    public GameObject exitButton;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        searchEngineTasksScript = GameObject.Find("Search Engine Panel").GetComponent<SearchEngineTasks>();
    }

    public void ExitClicks()
    {
        if (Clicks <= 2)
        {
            Clicks += 1;

            position = rectTransform.anchoredPosition;

            position = new Vector2(Random.Range(minHorizontalPos, maxHorizontalPos), Random.Range(minVerticalPos, maxVerticalPos));

            rectTransform.anchoredPosition = position;
        }      
        else
        {
            Debug.Log("Done");
            window.SetActive(false);
            exitButton.SetActive(false);

            searchEngineTasksScript.ExitButtons += 1;
        }
    }
}
