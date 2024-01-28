using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas UI;
    public Canvas ComputerScreen;
    public GameObject NoInternet;

    public TMP_InputField wifiInput;
    public GameObject wifiPrompt;
    public TextMeshProUGUI routerNotFound;

    public GameObject computerPrompt;
    public GameObject routerPrompt;
    public GameObject picturePrompt;
    public GameObject picture;
    public GameObject printerPrompt;
    public GameObject paperPrompt;
    public GameObject paperplacePrompt;
    public GameObject movingPaper;
    public GameObject printingPaper;
    public GameObject instructions;
    public GameObject reamOfPaper;
    public GameObject emailButton;

    public Camera mainCamera;

    public bool routerON;
    public bool inComputer;
    public bool paperTaken;
    public bool paperPlaced;
    public bool imageSentToPrint;
    public bool imagePrinted;
    public bool emailSent;

    public float zoomSpeed;
    public float targetZoom;
    public float defaultZoom;

    private GameObject printedPaper;
    private bool passCorrect;

    void Start()
    {
        paperplacePrompt.SetActive(false);
        paperPlaced = false;
        mainCamera = Camera.main;
        UI.gameObject.SetActive(true);
        ComputerScreen.gameObject.SetActive(false);
        routerON = false;
        inComputer = false;
        mainCamera.GetComponent<CameraRotation>().enabled = false;
        wifiInput.gameObject.SetActive(false);
        wifiPrompt.SetActive(false);
        reamOfPaper.GetComponent<HitByRay>().enabled = false;
        emailButton.gameObject.SetActive(false);
        imagePrinted = false;
        emailSent = false;

        printedPaper = GameObject.Find("PaperPrinted").gameObject;
        printedPaper.SetActive(false);
        passCorrect = false;
    }


    void Update()
    {
        if (imageSentToPrint)
        {
            reamOfPaper.GetComponent<HitByRay>().enabled = true;
        }

        if (routerON && passCorrect ==false)
        {
            wifiInput.gameObject.SetActive(true);
            wifiPrompt.SetActive(true);

            if (wifiInput.text.ToString() == "ilikeoldbunsandicannotlieandotherbrotherscan'tdeny")
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    NoInternet.SetActive(false);
                    routerNotFound.text = "Router connected!";
                    wifiInput.gameObject.SetActive(false);
                    wifiPrompt.gameObject.SetActive(false);
                    passCorrect = true;

                    DialogueManager.instance.enterDialogueMode(Resources.Load<TextAsset>("DialogueTXTs/GrannyDialogue"));
                    ///granny and play sound
                }
            }
        }

        if (gameObject.GetComponent<RayObjectChecking>().currentObject == "Computer")
        {
            computerPrompt.gameObject.SetActive(true);
        }
        else { computerPrompt.gameObject.SetActive(false); }

        if (gameObject.GetComponent<RayObjectChecking>().currentObject == "Router")
        {
            routerPrompt.gameObject.SetActive(true);
        }
        else { routerPrompt.gameObject.SetActive(false); }

        if (gameObject.GetComponent<RayObjectChecking>().currentObject == "Picture")
        {
            picturePrompt.gameObject.SetActive(true);
        }
        else { picturePrompt.gameObject.SetActive(false); }

        if (gameObject.GetComponent<RayObjectChecking>().currentObject == "Printer")
        {
            if (paperTaken)
            {
                paperplacePrompt.gameObject.SetActive(true);

                if (Input.GetMouseButton(0))
                {
                    movingPaper.SetActive(false);
                    printingPaper.SetActive(true);
                    paperTaken = false;
                    paperPlaced = true;
                    paperplacePrompt.gameObject.SetActive(false);
                    printerPrompt.gameObject.SetActive(true);
                }
            } else
            {
                paperplacePrompt.gameObject.SetActive(false);
            }

            if (paperPlaced)
            {
                printerPrompt.gameObject.SetActive(true);

                if (Input.GetMouseButton(0))
                {
                    imagePrinted = true;
                    printedPaper.SetActive(true);
                    emailButton.gameObject.SetActive(true);
                    paperPlaced = false;
                    movingPaper.SetActive(false);

                    DialogueManager.instance.enterDialogueMode(Resources.Load<TextAsset>("DialogueTXTs/GrannyDialogue"));
                }
            } else
            {
                printerPrompt.gameObject.SetActive(false);
            }
        }
        else { printerPrompt.gameObject.SetActive(false); }

        if (gameObject.GetComponent<RayObjectChecking>().currentObject == "ReamOfPaper" && imageSentToPrint)
        {
            paperPrompt.gameObject.SetActive(true);
        }
        else { paperPrompt.gameObject.SetActive(false); }

        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.GetComponent<RayObjectChecking>().currentObject == "Computer")
            {
                goIntoComputer();
            }

            if (gameObject.GetComponent<RayObjectChecking>().currentObject == "Picture")
            {
                removePicture();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitComputer();
        }

        
    }

    public void goIntoComputer()
    {
        UI.gameObject.SetActive(false);
        StartCoroutine(ZoomInCamera());
        inComputer = true;
        mainCamera.GetComponent<CameraRotation>().enabled = false;
    }

    public void exitComputer()
    {
        UI.gameObject.SetActive(true);
        StartCoroutine(ZoomOutCamera());
        inComputer = false;
        instructions.SetActive(true);
        mainCamera.GetComponent<CameraRotation>().enabled = true;
    }

    public void removePicture()
    {
        picture.gameObject.SetActive(false);
    }

    IEnumerator ZoomInCamera()
    {
        while (mainCamera.fieldOfView > targetZoom)
        {
            mainCamera.fieldOfView -= zoomSpeed * Time.deltaTime;
            yield return null;
        }
        ComputerScreen.gameObject.SetActive(true);
    }
    
    IEnumerator ZoomOutCamera()
    {
        ComputerScreen.gameObject.SetActive(false);

        while (mainCamera.fieldOfView < defaultZoom)
        {
            mainCamera.fieldOfView += zoomSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
