using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    float moveInput;

    public bool IsMoving { get; set;}

    Rigidbody2D rb;

    Animator _animator;

    SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        _animator.SetFloat("speed", rb.velocity.magnitude);

        switch (moveInput)
        {
            case -1:
                _spriteRenderer.flipX = true;
                break;
            case 1:
                _spriteRenderer.flipX = false;
                break;
            case 0:
                break;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;

        IsMoving = moveInput != 0;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(moveInput, jumpForce);
        }
    }
}
