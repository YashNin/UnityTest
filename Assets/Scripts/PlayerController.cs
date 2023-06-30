using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;

    public float gravity;
    public float forwardMoveSpeed, sideMoveSpeed, rotationSpeed;

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

        ApplyGravity();
    }

    private void LateUpdate()
    {
        Rotate();
    }

    void Move()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float sideInput = Input.GetAxisRaw("Horizontal");

        Vector3 forwardVector = forwardInput * forwardMoveSpeed * transform.forward;
        Vector3 sideVector = sideInput * sideMoveSpeed * transform.right;

        characterController.Move((forwardVector + sideVector) * Time.deltaTime);

        animator.SetFloat("ForwardMovement", forwardInput);
    }

    void Rotate()
    {
        float mouseRotateVector = Input.GetAxis("Mouse X");

        Vector3 characterRotateVector = new( 0, mouseRotateVector * rotationSpeed, 0);

        transform.Rotate(characterRotateVector *  Time.deltaTime);
    }

    void ApplyGravity()
    {
        characterController.Move(new Vector3(0, gravity * Time.deltaTime, 0));
    }
}
