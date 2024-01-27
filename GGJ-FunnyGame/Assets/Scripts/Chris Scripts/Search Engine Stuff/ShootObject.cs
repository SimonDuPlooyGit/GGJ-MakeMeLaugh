using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootObject : MonoBehaviour
{
    public GameObject bullet;
    public GameObject ad;

    public GameObject aimed;

    private float speed = 800;

    public bool shot;

    public ShootingGame shootObjectScript;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (shot)
        {
            Shoot();
        }

        if (bullet.GetComponent<RectTransform>().anchoredPosition == ad.GetComponent<RectTransform>().anchoredPosition)
        {
            bullet.SetActive(false);
            ad.SetActive(false);
            shootObjectScript.Shooted += 1;
        }
    }

    private void Shoot()
    { 
        bullet.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(bullet.GetComponent<RectTransform>().anchoredPosition, 
            ad.GetComponent<RectTransform>().anchoredPosition, speed * Time.deltaTime);
        
    }

    public void ShotAt()
    {
        shot = true;
    }
}
