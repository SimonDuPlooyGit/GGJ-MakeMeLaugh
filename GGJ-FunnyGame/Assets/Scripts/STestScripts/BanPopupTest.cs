using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BanPopupTest : MonoBehaviour
{
    public float banTime;
    private float timer;
    public TextMeshProUGUI timerText;
    public GameObject confirmButton;
    public GameObject plane;
    public GameObject backgroundPanel;

    void Start()
    {
        plane.SetActive(true);
        confirmButton.SetActive(false);
        StartTimer();     
    }

    void Update()
    {
        int timerRounded = Mathf.RoundToInt(timer);

        timerText.text = "You have sent (1028) emails to one recipient within 24 hours and are hence under a temporary (" + timerRounded.ToString() + ") second email ban";

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            
            if (timer <= 0f)
            {
                confirmButton.SetActive(true);
                Debug.Log("Timer Done");
            }
        }
    }

    public void StartTimer()
    {
        timer = banTime;
    }

    public void RemoveMessage()
    {
        backgroundPanel.SetActive(false);
        gameObject.SetActive(false);
        plane.GetComponent<PlaneFlying>().enabled = true;
    }
}
