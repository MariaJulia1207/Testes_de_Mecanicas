using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI")]
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private Image portraitImage;

    [SerializeField] private TMP_Text speakerNameText;

    [SerializeField] private TMP_Text dialogueText;

    private DialogueData currentDialogue;

    private int currentLine;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(DialogueData dialogue)
    {
        currentDialogue = dialogue;
        currentLine = 0;

        dialoguePanel.SetActive(true);

        UpdateUI();
    }

    public void NextLine()
    {
        currentLine++;

        if (currentLine >= currentDialogue.dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        DialogueLine line =
            currentDialogue.dialogueLines[currentLine];

        portraitImage.sprite = line.portrait;

        speakerNameText.text =
            line.speakerName;

        dialogueText.text =
            line.dialogueText;
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}