using UnityEngine;
using System;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public static event Action<string, string, Sprite> OnDialogueLineChanged;
    public static event Action OnDialogueStarted;
    public static event Action OnDialogueEnded;

    private NPCDialogueData currentDialogue;
    private NPCInteractable currentNPC;

    private int currentLine;
    private bool dialogueActive;

    public bool IsDialogueActive => dialogueActive;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartDialogue(
        NPCInteractable npc,
        NPCDialogueData dialogue)
    {
        currentNPC = npc;
        currentDialogue = dialogue;
        currentLine = 0;
        dialogueActive = true;

        OnDialogueStarted?.Invoke();

        ShowCurrentLine();
    }

    private void Update()
    {
        if (!dialogueActive)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    private void ShowCurrentLine()
    {
        OnDialogueLineChanged?.Invoke(
            currentDialogue.npcName,
            currentDialogue.dialogueLines[currentLine],
            currentDialogue.portrait
        );
    }

    public void NextLine()
    {
        currentLine++;

        if (currentLine >= currentDialogue.dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        ShowCurrentLine();
    }

    private void EndDialogue()
    {
        dialogueActive = false;

        if (currentNPC != null)
            currentNPC.MarkDialogueCompleted();

        OnDialogueEnded?.Invoke();
    }
}