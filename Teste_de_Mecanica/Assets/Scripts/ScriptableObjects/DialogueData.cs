using UnityEngine;

[CreateAssetMenu(fileName = "NovoDialogo", menuName = "Dialogos/NPC")]
public class NPCDialogueData : ScriptableObject
{
    public string npcName;
    public Sprite portrait;

    [TextArea(3, 5)]
    public string[] dialogueLines;
}