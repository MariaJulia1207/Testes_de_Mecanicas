using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteractable : MonoBehaviour
{
    [Header("Diálogo")]
    public NPCDialogueData dialogueData;

    [Header("Configurações")]
    public bool repeatDialogue = false;

    private bool playerInRange;
    private bool dialogueCompleted;

    private void Update()
    {
        if (!playerInRange)
            return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (dialogueCompleted && !repeatDialogue)
                return;

            DialogueManager.Instance.StartDialogue(this, dialogueData);
        }
    }

    public void MarkDialogueCompleted()
    {
        dialogueCompleted = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}