using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    private string[] actorNames = {"Belmonte", "Konstanze", "Pedrillo", "Osmin", "Selim"};

    Message[] currentMessages;
    Actor[] currentActors;
    private GameObject currentLight;
    private AudioSource currentAudio;
    int activeMessage = 0;
    public static bool isDialogueActive = false;
    [HideInInspector] public int dialogueIndex = 0;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isDialogueActive = true;
        dialogueIndex++;
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;
        currentAudio = messageToDisplay.audioSource;
        currentAudio.Play();
        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
        if (messageToDisplay.message.Split(' ').Length > 50)
        {
            messageText.fontSize = 15;

        }
        else
        {
            messageText.fontSize = 20;
        }
        foreach (var s in actorNames)
        {
            if (actorName.text.Contains(s))
            {
                currentLight = GameObject.Find(s + " Light");
                currentLight.GetComponent<Light2D>().enabled = true;
            }
        }
        AnimateTextColor();
    }

    public void NextMessage()
    {
        activeMessage++;
        currentLight.GetComponent<Light2D>().enabled = false;
        if (activeMessage < currentMessages.Length)
        {
            currentAudio.Stop();
            DisplayMessage();
        }
        else
        {
            currentAudio.Stop();
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            FindObjectOfType<Story>().Execute(dialogueIndex);
            isDialogueActive = false;
        }
    }

    void AnimateTextColor()
    {
        LeanTween.value(gameObject, new Color(1, 1, 1, 0), new Color(0, 0, 0, 0.75f), 0.5f).setOnUpdate((Color val) =>
        {
            messageText.color = val;
            actorName.color = val;
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            NextMessage();
        }
    }
}