using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Wallrunning")]
    public WallRunning wallrun;
    public float wallrunningCap;
    public bool wallrunning = false;

    [Header("Camera")]
    public float rotation;
    public Transform target;

    [Header("GameObjects")]

    public Animator anim;
    [SerializeField] CharacterController _controller;
    public float walkingspeed;

    public float waterDistance = 0.4f;
    public LayerMask waterMask;

    private bool isWater;

    [Header("player")]

    public bool CanDoubleJump;
    public int Jumpcount;
    [SerializeField] float _playerSpeed;
    [SerializeField] float _playerSprint;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float wallrunrotationSpeed;
    [SerializeField] Camera _followCamera;
    [SerializeField] Vector3 _playerVelocity;
    public bool _groundedPlayer;
    [SerializeField] float _jumpHeight = 1.0f;
    public float _gravityValue = -9.81f;
    public Transform waterCheck;

   //float _upInmersive = 2.0f;

    private void Start()
    {
        wallrun = GetComponent<WallRunning>();
        anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        rotation = -30f;
        _playerSpeed = walkingspeed;
        _groundedPlayer = _controller.isGrounded;
        Input.GetKeyDown(KeyCode.Mouse1);
        Input.GetKeyUp(KeyCode.Mouse1);
        anim.SetBool("Movement", false);
        anim.SetBool("Run", false);
        //anim.SetBool("Dublejump", false);
        anim.SetBool("Wallrun", false);


        Movement();

        if (_groundedPlayer)
        {
            wallrunningCap = 1;
            Jumpcount = 0;
            anim.SetBool("Wallrun", false);
            anim.SetBool("Grounded", true);
        }
        if (Input.GetKey(KeyCode.Q)) Run();
        if (Input.GetKeyDown("space") && Jumpcount < 2 && CanDoubleJump) DoubleJump();
        if (Input.GetButton("Jump") && _groundedPlayer) Jump();



    }

    void Run()
    {
        _playerSpeed = _playerSpeed * _playerSprint;
        anim.SetBool("Run", true);
    }
    void Jump()
    {
        _playerVelocity.y = 0f;
        _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        anim.SetBool("Grounded", false);

    }
    void DoubleJump()
    {
        // anim.SetBool("Dublejump", true);
        _playerVelocity.y = 0f;
        _playerVelocity.y += Mathf.Sqrt(_jumpHeight * 2 * -3.0f * _gravityValue);
        Jumpcount++;
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
       
        
            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }
            Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
            Vector3 movementDirection = movementInput.normalized;
            _controller.Move(movementDirection * _playerSpeed * Time.deltaTime);

            _playerVelocity.y += _gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);
            if (movementDirection != Vector3.zero)
            {
                anim.SetBool("Movement", true);
                Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
                if (wallrunning == true)
                {
                    anim.SetBool("Wallrun", true);
                    //anim.SetBool("Dublejump", false);
                    if (wallrun.wallLeft)
                    {
                        Jumpcount = 0;
                        wallrunningCap--;
                        desiredRotation = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, rotation);
                        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, wallrunrotationSpeed * Time.deltaTime);
                    }
                    if (wallrun.wallRight)
                    {
                        Jumpcount = 0;
                        Debug.Log(rotation);
                        if (rotation < 0) rotation = -rotation;
                        wallrunningCap--;
                        desiredRotation = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, rotation);
                        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, wallrunrotationSpeed * Time.deltaTime);
                    }
                }
            }

            isWater = Physics.CheckSphere(waterCheck.position, waterDistance, waterMask);

            if(isWater)
            {
                Debug.Log("ESTA EN EL AGUA");
                _groundedPlayer = false;
                 _gravityValue = -0.5f;
                 _playerVelocity.y = _playerVelocity.y - _gravityValue * Time.deltaTime;
                 anim.SetBool("Wallrun", false);
                 anim.SetBool("Inmerse", true);
                 
                 
                if (movementDirection != Vector3.zero)
                {
                    anim.SetBool("Swim", true);
                    anim.SetBool("Inmerse", false);
                }else{
                    anim.SetBool("Inmerse", true);
                }

                
            }
    }

}