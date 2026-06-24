using UnityEngine;

[CreateAssetMenu(
    fileName = "DialogueData",
    menuName = "Dialogue System/Dialogue Data"
)]
public class DialogueData : ScriptableObject
{
    [Header("NPC")]
    public string npcName;

    public Sprite portrait;

    [Header("Linhas")]
    [TextArea(2,5)]
    public string[] dialogueLines;
} 