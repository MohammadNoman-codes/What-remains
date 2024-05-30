using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;

    [SerializeField]
    private float lookSenesitivity = 5;

    [SerializeField]
    private float jumpHeight = 10;

    [SerializeField]
    private float gravity = 9.81f;

    private Vector2 moveVector;
    private Vector2 lookVector;
    private Vector3 rotation;
    private float verticalvelocity;




    private CharacterController characterController;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Attack();

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        if (moveVector.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

    }

    private void Move()
    {
        verticalvelocity += -gravity * Time.deltaTime;

        if (characterController.isGrounded && verticalvelocity < 0)
        {
            verticalvelocity = -0.1f * gravity * Time.deltaTime;
        }
        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.y + transform.up * verticalvelocity;
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    public void Onlook(InputAction.CallbackContext context)
    {
        lookVector = context.ReadValue<Vector2>();
    }

    private void Rotate()
    {
        rotation.y += lookVector.x * lookSenesitivity * Time.deltaTime;
        transform.localEulerAngles = rotation;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded && context.performed)
        {
            animator.Play("Jump");
            Jump();
        }
    }

    private void Jump()
    {
        verticalvelocity = Mathf.Sqrt(jumpHeight * gravity);
    }


    public void onAttack(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded && context.performed)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.Play("Attack");
        }
    }

    public void onJumpAttack(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded && context.performed)
        {
            JumpAttack();
        }
    }

    private void JumpAttack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.Play("JumpAttack");
        }
    }


}