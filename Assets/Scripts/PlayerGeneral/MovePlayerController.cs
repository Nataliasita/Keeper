using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraObjetive;
    public float speed = 6f;
    public float gravity =-9.81f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity = 0.1f;

    Vector3 velocity;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundCheck;
    private bool isGrounded;
    public float jumpForce = 3f;

    public Animator animator;
    public string movementAnimator;
    public string groundAnimator;



    void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        animator.SetFloat(movementAnimator, (Mathf.Abs(vertical) + Mathf.Abs(horizontal)));

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        velocity.y +=gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        animator.SetBool(groundAnimator , controller.isGrounded);
        
        if(isGrounded && velocity.y < 0 )
        {
            velocity.y = gravity;
        }

        if(direction.magnitude >= 0.1f)
        {   
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraObjetive.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle ,0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }

    }
}
