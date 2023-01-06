using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Principal          
    private Camera m_Camera;
    private CharacterController m_CharacterController;

    [Header("Variables de Movimiento")]     //Header nos permite poner un titulo a las variables en el inspector
    [SerializeField]                        //Nos permite ver en el inspector variables privada
    private float m_MoveSpeed = 5.0f;
    [SerializeField]
    private float m_JumpForce = 5.0f;
    [SerializeField]
    private float m_GravityForce = 9.807f;

    [Range(0.0f, 5.0f)]                     //Nos permite crear un rango en el inspector
    public float m_LookSensitivity = 1.0f;

    [Header("Debugging Variables")]
    [SerializeField]
    private float m_MouseX;
    [SerializeField]
    private float m_MouseY;

    [SerializeField]
    private Vector3 m_MoveDirection;

    private bool underwater;
    //private Storm stormScript; 
    private UnderWater underWaterScrip;

    void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        m_CharacterController = this.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        //stormScript = GameObject.Find("LuzSol").GetComponent<Storm>();
        underWaterScrip = GameObject.Find("Water").GetComponent<UnderWater>();
    }

    void Update()
    {
        Rotate();
        Movement();
    }

    private void Rotate()
    {
        // Recivo la entrada del mouse y la sensibilidad
        m_MouseX += Input.GetAxisRaw("Mouse X") * m_LookSensitivity;
        m_MouseY += Input.GetAxisRaw("Mouse Y") * m_LookSensitivity;

        // Limito MouseY entre -90 y 90
        m_MouseY = Mathf.Clamp(m_MouseY, -90.0f, 90.0f);

        // Roto el player en el eje Y
        transform.localRotation = Quaternion.Euler(Vector3.up * m_MouseX);
        // Roto la camara en X 
        //m_camera.transform.localRotation = Quaternion.Euler(-mouseY, m_camera.transform.locolRotation.y, 0.0f); esta manera es util si rotaramos los 3 eje
        m_Camera.transform.localRotation = Quaternion.Euler(Vector3.left * m_MouseY);//Forma correcta para rotar un eje 
    }

    private void Movement()
    {
        // Esta el player en el suelo
        if (m_CharacterController.isGrounded && !underwater)
        {
            // Recive la entrada de movimiento
            Vector3 forwardMovement = transform.forward * Input.GetAxisRaw("Vertical");//Esta es una forma de declarar variables privada internas en la funcion
            Vector3 strafeMovement = transform.right * Input.GetAxisRaw("Horizontal");
            // Convierte la entrad en Vector3
            m_MoveDirection = (forwardMovement + strafeMovement).normalized * m_MoveSpeed;
            // Si presiono space salto
            if (Input.GetKeyDown(KeyCode.Space)) // Esta manera sin {} es valida pero a mi no me gusta
                m_MoveDirection.y = m_JumpForce; // Salto
        }

        // Calculo y aplico gravedad al movimiento
        m_MoveDirection.y -= m_GravityForce * Time.deltaTime;

        // Envio informacion de movimiento al character controller
        m_CharacterController.Move(m_MoveDirection * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            underwater = true;
            // Recive la entrada de movimiento
            Vector3 forwardMovement = m_Camera.transform.forward * Input.GetAxisRaw("Vertical");//Esta es una forma de declarar variables privada internas en la funcion
            Vector3 strafeMovement = m_Camera.transform.right * Input.GetAxisRaw("Horizontal");
            // Convierte la entrad en Vector3
            m_MoveDirection = (forwardMovement + strafeMovement).normalized * (m_MoveSpeed/3);
            // Si presiono space salto
            if (Input.GetKey(KeyCode.Space))
            {
                m_MoveDirection.y += (m_GravityForce + m_JumpForce) * 3 * Time.deltaTime; // Floto
            }
            //stormScript.underWater = true;
            underWaterScrip.underWater = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Agua")
        {
            underwater = false;
            //stormScript.underWater = false;
            underWaterScrip.underWater = false;
        }
    }
}
