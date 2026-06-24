using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("Referências")]
    public Image portraitImage;

    public TMP_Text nameText;

    public TMP_Text dialogueText;

    private void OnEnable()
    {
        ObserverManager.OnDialogueStarted += OpenUI;
        ObserverManager.OnDialogueEnded += CloseUI;
        ObserverManager.OnDialogueUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        ObserverManager.OnDialogueStarted -= OpenUI;
        ObserverManager.OnDialogueEnded -= CloseUI;
        ObserverManager.OnDialogueUpdated -= UpdateUI;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OpenUI()
    {
        gameObject.SetActive(true);
    }

    private void CloseUI()
    {
        gameObject.SetActive(false);
    }

    private void UpdateUI(
        string npcName,
        string dialogue,
        Sprite portrait)
    {
        nameText.text = npcName;

        dialogueText.text = dialogue;

        portraitImage.sprite = portrait;
    }
}