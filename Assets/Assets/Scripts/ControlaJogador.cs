using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlaJogador : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private Rigidbody2D rb;

    public Animator animator;

    public InputAction playerControls;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Input

        moveDirection = playerControls.ReadValue<Vector2>();

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if(animator.GetFloat("Horizontal") == 1 || animator.GetFloat("Horizontal") == -1  
            || animator.GetFloat("Vertical") == 1 || animator.GetFloat("Vertical") == -1)
        {
            animator.SetFloat("LastMoveX", animator.GetFloat("Horizontal"));
            animator.SetFloat("LastMoveY", animator.GetFloat("Vertical"));
        }

    }

    private void FixedUpdate()
    {
        // Movement
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //animator.SetFloat("Speed", moveSpeed);
    }
}
