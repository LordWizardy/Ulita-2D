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

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
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
