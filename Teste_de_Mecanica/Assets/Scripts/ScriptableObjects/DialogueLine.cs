using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public Sprite portrait;

    public string speakerName;

    [TextArea(2, 5)]
    public string dialogueText;
}