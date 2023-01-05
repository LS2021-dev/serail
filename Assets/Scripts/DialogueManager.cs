using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isDialogueActive = false;
    public int currentDialogueID = 0;
    private Story story;
    private GameObject notes;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isDialogueActive = true;
        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        currentDialogueID++;
        if (currentDialogueID == 2)
        {
            GameObject.Find("Romanze_Pedrillo").SetActive(false);
        }
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        if (messageToDisplay.message.Contains("*"))
        {
            messageText.fontStyle = FontStyles.Italic;
            messageText.text = messageToDisplay.message.Replace("*", "");
            notes.SetActive(true);
        }
        else
        {
            messageText.fontStyle = FontStyles.Normal;
            messageText.text = messageToDisplay.message;
            notes.SetActive(false);
        }

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
        AnimateTextColor();
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation ended!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            story.Execute(currentDialogueID);
            Thread.Sleep(100); // Buääh...
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
        story = GameObject.Find("Story").GetComponent<Story>();
        notes = GameObject.Find("Notes_Pedrillo");
        notes.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDialogueActive)
        {
            NextMessage();
        }
    }
}