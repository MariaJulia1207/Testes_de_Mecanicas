using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;

    private Rigidbody2D rb;
    private Vector2 movimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (DialogueManager.Instance != null &&
            DialogueManager.Instance.IsDialogueActive)
        {
            movimento = Vector2.zero;
            return;
        }

        movimento = Vector2.zero;

        if (Keyboard.current.leftArrowKey.isPressed)
            movimento.x = -1;

        if (Keyboard.current.rightArrowKey.isPressed)
            movimento.x = 1;

        if (Keyboard.current.upArrowKey.isPressed)
            movimento.y = 1;

        if (Keyboard.current.downArrowKey.isPressed)
            movimento.y = -1;

        movimento = movimento.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movimento * velocidade;
    }
}