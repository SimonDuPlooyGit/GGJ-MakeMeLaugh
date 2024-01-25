using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BanPopupTest : MonoBehaviour
{
    public float banTime;
    public float timer;
    public TextMeshProUGUI timerText;

    void Start()
    {
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
                Debug.Log("Timer Done");
            }
        }
    }

    public void StartTimer()
    {
        timer = banTime;
    }
}
