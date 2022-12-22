using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    private float mouseSensitivity = 3.0f;
    private float rotationY;
    private float rotationX;

    [SerializeField]
    private float distanceFromTarget;
    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    [SerializeField]
    private float smoothTime;

    [SerializeField]
    private Vector2 rotationXMinMax;

    [SerializeField]
    private Vector2 rotationYMinMax;
    public Vector3 CameraOffset;
    public GameObject player;
    public bool IsAiming;

    [Header("memory")]
    private float distanceFromTargetMemory;
    public Vector3 CameraOffsetMemory;
    private Vector2 rotationXMinMaxMemory;
    private Vector2 rotationYMinMaxMemory;
    private bool CameraCanMove;
    private Vector3 MovementPosition;
    public GameObject target;
    public GameObject targetEnemy;

    private void Start()
    {
        rotationYMinMaxMemory = rotationYMinMax;
        rotationXMinMaxMemory = rotationXMinMax;
        distanceFromTargetMemory = distanceFromTarget;
        CameraOffsetMemory = CameraOffset;
        StartCoroutine(LerpPosition(player.transform.position + CameraOffset - transform.forward * distanceFromTarget, 0.5f, player.transform.rotation));
    }

    void Update()
    {
        //targetEnemy = player.GetComponent<PlayerCombatMovement>().target;
        Quaternion CamDesiredRotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x,
        player.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z);
        MovementPosition = player.transform.position + CameraOffset - transform.forward * distanceFromTarget;

        if (Input.GetKeyDown(KeyCode.Space) && !player.GetComponent<PlayerCombatMovement>().InCombat) StartCoroutine(LerpPosition(target.transform.position, 1f, target.transform.rotation));
        if (Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerCombatMovement>().InCombat) StartCoroutine(LerpPosition(target.transform.position, 0.5f, target.transform.rotation));
        if (Input.GetKeyDown(KeyCode.Q) && player.GetComponent<PlayerCombatMovement>().InCombat) StartCoroutine(LerpPosition(MovementPosition, 0.5f, CamDesiredRotation));
        if (player.GetComponent<PlayerCombatMovement>().InCombat) IsInCombact();
        if (!player.GetComponent<PlayerCombatMovement>().InCombat) Iswalking();
        if (IsAiming && !player.GetComponent<PlayerCombatMovement>().InCombat) IsAimingTo();
        if (!IsAiming) MemoryValues();
    }
    void IsInCombact()
    {
        if (CameraCanMove)
        {
            transform.position = target.transform.position;
            this.transform.rotation = target.transform.rotation;
        }

    }
    void Iswalking()
    {
        if (CameraCanMove)
        {
            InputRotation();
            transform.position = MovementPosition;
        }

    }
    void IsAimingTo()
    {
        //Stablisch the new camera position
        distanceFromTarget = 1.2f;
        CameraOffset = new Vector3(0.35f, 1.4f, 0.5f);
        rotationXMinMax = new Vector2(-20f, 20f);
        rotationYMinMax = new Vector2(-20f, 30f);
        // Emulates camera rotation in Y axis
        Quaternion DesiredRotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x,
        this.transform.rotation.eulerAngles.y, player.transform.rotation.eulerAngles.z);
        player.transform.rotation = DesiredRotation;
    }
    void InputRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationY += mouseX;
        rotationX += -mouseY;
        rotationX = Mathf.Clamp(rotationX, rotationXMinMax.x, rotationXMinMax.y);
        rotationY = Mathf.Clamp(rotationY, rotationYMinMax.x, rotationYMinMax.y);
        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;
    }
    void MemoryValues()
    {
        distanceFromTarget = distanceFromTargetMemory;
        CameraOffset = CameraOffsetMemory;
        rotationXMinMax = rotationXMinMaxMemory;
        rotationYMinMax = rotationYMinMaxMemory;
    }
    IEnumerator LerpPosition(Vector3 desiredPosition, float duration, Quaternion LerpRotation)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            CameraCanMove = false;
            transform.position = Vector3.Lerp(startPosition, desiredPosition, time / duration);
            transform.rotation = Quaternion.Lerp(transform.rotation, LerpRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = desiredPosition;
        CameraCanMove = true;
    }
}
