using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatMovement : MonoBehaviour
{
    [Header("Movement")]
    public float jumpForce;
    public float jumpCount;
    public float sprintSpeed;
    private float memorySpeed;
    public bool IsSprinting;
    public bool IsCrouching;

    [Header("Camera")]
    [SerializeField] Camera followCamera;

    [Header("GameObjects")]
    [SerializeField] CharacterController controller;
    private Animator anim;

    [Header("player")]
    [SerializeField] float playerSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 playerVelocity;
    public float gravityValue = -9.81f;
    public Vector3 offset;

    [Header("player State")]
    public bool InCombat;
    private CombatSystem combatSystem;
    private DetectorSensor Sensor;
    public GameObject sensorDetector;
    public GameObject target;
    public int EnemyIndex;
    void Start()
    {
        memorySpeed = playerSpeed;
        Sensor = sensorDetector.GetComponent<DetectorSensor>();
        combatSystem = GetComponent<CombatSystem>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Cambio de enemigo seleccionado
        if (Input.GetKeyDown(KeyCode.E) && Sensor.enemyInRange.Count > 1)
        {
            int MemoryIndex;
            MemoryIndex = EnemyIndex;
            if (EnemyIndex < Sensor.enemyInRange.Count) EnemyIndex += 1;
            if (EnemyIndex >= Sensor.enemyInRange.Count) EnemyIndex = 0;
            target = Sensor.enemyInRange[MemoryIndex].gameObject;
            target.GetComponent<UIEnemyelements>().DisableOutline();
        }
        if (Sensor.enemyInRange.Count == 0)
        {
            InCombat = false;
        }
        // animaciones
        if (InCombat)
        {
            target = Sensor.enemyInRange[EnemyIndex].gameObject;
            target.GetComponent<UIEnemyelements>().EnableOutline();
            if (target.GetComponent<EnemyStats>().health <= 0)
            {
                Sensor.enemyInRange.Remove(target);
                EnemyIndex = 0;
                followCamera.GetComponent<FollowPlayer>().LerpCamera();
            }
            if (target.GetComponent<EnemyStats>().weakpoints >= 3)
            {
                Sensor.enemyInRange.Remove(target);
                EnemyIndex = 0;
                followCamera.GetComponent<FollowPlayer>().LerpCamera();
            }
        }
        if (!InCombat)
        {
            for (int i = 0; i < Sensor.enemyInRange.Count; i++)
            {
                Sensor.enemyInRange[i].GetComponent<UIEnemyelements>().DisableOutline();
                if (!Sensor.enemyInRange[i].GetComponent<EnemyStats>().IsAlive)
                {
                    Sensor.RemoveEnemies(target);
                }
            }
        }
        Movement();
    }
    void Movement()
    {
        //Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;
        float walkInput = Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput);
        anim.SetFloat("Walk", walkInput);
        Debug.Log(walkInput);
        // imitates normal physics force if the player is grounded

        // Movement
        if (InCombat && target != null)
        {
            controller.Move(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed);
            transform.RotateAround(target.transform.position, Vector3.up, -horizontalInput * rotationSpeed * 15 * Time.deltaTime);
            transform.LookAt(target.transform.position - offset);
            playerVelocity.y += gravityValue * Time.deltaTime;
            if (controller.isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = gravityValue;
            }
        }
        else
        {
            controller.Move(movementDirection * playerSpeed * Time.deltaTime);
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
            if (controller.isGrounded) anim.SetBool("Grounded", true);
            if (controller.isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = gravityValue;
            }
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0 && !controller.isGrounded)
            {
                anim.SetBool("Grounded", false);
                anim.SetTrigger("DoubleJump");
                playerVelocity.y = Mathf.Sqrt(jumpForce * -2 * gravityValue);
                jumpCount--;
                anim.SetBool("Crouching", false);
                IsCrouching = false;
            }
            if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Grounded", false);
                anim.SetTrigger("Jump");
                playerVelocity.y = Mathf.Sqrt(jumpForce * -2 * gravityValue);
                jumpCount = 1;
                anim.SetBool("Crouching", false);

            }
            if (controller.isGrounded && Input.GetKeyDown(KeyCode.LeftControl))
            {
                Debug.Log("IsCrounching");
                anim.SetBool("Crouching", true);
                IsCrouching = true;
            }
            if (controller.isGrounded && Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetFloat("Walk", 3);
                playerSpeed = sprintSpeed;
                anim.SetBool("Crouching", false);
                IsCrouching = false;
            }
            else
            {
                anim.SetFloat("Walk", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
                playerSpeed = memorySpeed;
            }
            if (IsCrouching)
            {
                playerSpeed = playerSpeed / 2;
            }
            else if (!IsCrouching)
            {
                playerSpeed = memorySpeed;
            }
        }
        // Stay Camera move

        if (movementDirection != Vector3.zero && !InCombat)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
