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

    private AudioSource gmAudioSource;

    private void Start()
    {
        gmAudioSource = GameObject.Find("GameManager").gameObject.transform.GetComponent<AudioSource>();
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

        gmAudioSource.clip = Resources.Load<AudioClip>("Sounds/gun");
        gmAudioSource.Play();

        
    
    }

    public void ShotAt()
    {
        shot = true;
        transform.tag = "Untagged";
        if (GameObject.FindGameObjectWithTag("ad") == null)
        {
            DialogueManager.instance.enterDialogueMode(Resources.Load<TextAsset>("DialogueTXTs/GrannyDialogue"));
        }
    }
}
