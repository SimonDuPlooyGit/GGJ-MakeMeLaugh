using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGame : MonoBehaviour
{
    public GameObject Shooter;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public GameObject Bullet4;
    public GameObject Bullet5;
    public GameObject Bullet6;
    public GameObject Bullet7;
    public GameObject Bullet8;

    public GameObject Ad;

    public int Shooted;

    private void Start()
    {
        Shooter.SetActive(false);
        Bullet1.SetActive(false);
        Bullet2.SetActive(false);
        Bullet3.SetActive(false);
        Bullet4.SetActive(false);
        Bullet5.SetActive(false);
        Bullet6.SetActive(false);
        Bullet7.SetActive(false);
        Bullet8.SetActive(false);
    }

    private void Update()
    {
        if (Shooted == 8)
        {
            Shooter.SetActive(false);
        }
    }

    public void ShooterGameActivate()
    {
        Shooter.SetActive(true);
        Bullet1.SetActive(true);
        Bullet2.SetActive(true);
        Bullet3.SetActive(true);
        Bullet4.SetActive(true);
        Bullet5.SetActive(true);
        Bullet6.SetActive(true);
        Bullet7.SetActive(true);
        Bullet8.SetActive(true);

        Ad.SetActive(false);
    }
}
