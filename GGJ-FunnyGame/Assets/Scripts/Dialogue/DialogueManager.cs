using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    [Header("Load Globals Ink File")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    [SerializeField] private TextAsset grannyJSON;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private float typingSpeed;
    [SerializeField] private AudioSource audioSource;
    [Header("Display")]
    [SerializeField] private GameObject oneSprite;
    [SerializeField] private TextMeshProUGUI oneDialogue;
    

    private Story currentStory;
    private bool dialogueIsPlaying;
    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine= true;
    private DialogueVariables dialogueVariables;

    [Header("Choices UI")]
    [SerializeField] private GameObject continueBTN;

    private const string PORTRAIT_TAG = "portrait";
    private const string SPEAKER_TAG = "speaker";
    private const string AUDIO_TAG = "audio";


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);

        
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        
        enterDialogueMode(grannyJSON);
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }
    }

    public void enterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying=true;
        dialoguePanel.SetActive(true);
        //Debug.Log(dialoguePanel.activeSelf);

        dialogueVariables.StartListening(currentStory);
        continueStory();
    }

    public void continueStory()
    {
        if (canContinueToNextLine==true) 
        {
            if (currentStory.canContinue)
            {
                oneDialogue.transform.parent.gameObject.SetActive(false);

                continueBTN.SetActive(false);
                string placeHolder = currentStory.Continue();
                //Debug.Log(placeHolder);
                if (currentStory.currentTags.Count != 0)
                    handleTags(currentStory.currentTags, placeHolder);
                else
                    Debug.Log("Missing");

            }
            else
            {
                exitDialogueMode();
            }
        }
            
    }

    private void handleTags(List<string> currentTags, string tempText)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            //Debug.Log(tag);
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag is incorrect: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            
            switch(tagKey)
            {
                case SPEAKER_TAG:
                        oneDialogue.transform.parent.gameObject.SetActive(true);
                        //nolwaziDialogue.text = tempText;
                        if (displayLineCoroutine != null)
                        {
                            StopCoroutine(displayLineCoroutine);
                        }
                        displayLineCoroutine = StartCoroutine(displayLine(oneDialogue, tempText));
                        oneSprite.gameObject.SetActive(true);
                    break;

                case PORTRAIT_TAG:
                    oneSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("GrannySprites/"+ tagValue);
                    //Debug.Log(oneSprite.GetComponent<Image>().sprite.ToString());
                    break;

                case AUDIO_TAG:
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/Granny/"+tagValue);
                    audioSource.Play();
                    break;

            }
            
        }
    }

    public void exitDialogueMode()
    {
        dialogueVariables.StopListening(currentStory);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private IEnumerator displayLine(TextMeshProUGUI dialogueCurry, string line)
    {
        dialogueCurry.text = "";
        canContinueToNextLine = false;
        foreach (char letter in line)
        {
            dialogueCurry.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        canContinueToNextLine = true;
        //Debug.Log(canContinueToNextLine);
        continueBTN.SetActive(true);
    }

}
