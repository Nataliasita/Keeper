using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatMovement : MonoBehaviour
{
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
    public GameObject target;
    public int EnemyIndex;
    void Start()
    {
        combatSystem = GetComponent<CombatSystem>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Debug.Log(EnemyIndex);
        //Cambio de enemigo seleccionado
        if (Input.GetKeyDown(KeyCode.E) && EnemyIndex <= combatSystem.enemyInRange.Length)
        {
            EnemyIndex += 1;
            if (EnemyIndex > combatSystem.enemyInRange.Length - 1) EnemyIndex = 0;
        }
        // animaciones
        if (InCombat) target = combatSystem.enemyInRange[EnemyIndex].gameObject;
        Movement();
    }
    void Movement()
    {
        //Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        anim.SetFloat("Walk", Mathf.Abs(horizontalInput + verticalInput));

        // Movement
        if (InCombat)
        {
            controller.Move(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed);
            transform.RotateAround(target.transform.position, Vector3.up, -horizontalInput * rotationSpeed * 15 * Time.deltaTime);
            transform.LookAt(target.transform.position - offset);
            playerVelocity.y += gravityValue * Time.deltaTime;
        }
        else
        {
            controller.Move(movementDirection * playerSpeed * Time.deltaTime);
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        // Stay Camera move

        if (movementDirection != Vector3.zero && !InCombat)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
