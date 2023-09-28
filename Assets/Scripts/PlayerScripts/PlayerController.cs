using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private InputActionReference inputActionMove;
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;

    public event EventHandler<Vector2> OnMoveEvent;
    public event EventHandler OnAttackEvent;

    private void Awake()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnAttack()
    {
        OnAttackEvent?.Invoke(this, EventArgs.Empty);
    }

    void Update()
    {
        Vector2 moveDirection = inputActionMove.action.ReadValue<Vector2>();
        Vector2 offset = moveDirection * speed * Time.deltaTime;

        rb.MovePosition(rb.position + offset);

        OnMoveEvent?.Invoke(this, offset);
    }
}
