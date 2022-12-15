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
    public GameObject target;
    public bool IsAiming;

    [Header("memory")]
    private float distanceFromTargetMemory;
    public Vector3 CameraOffsetMemory;
    private Vector2 rotationXMinMaxMemory;
    private Vector2 rotationYMinMaxMemory;
    private void Start()
    {
        rotationYMinMaxMemory = rotationYMinMax;
        rotationXMinMaxMemory = rotationXMinMax;
        distanceFromTargetMemory = distanceFromTarget;
        CameraOffsetMemory = CameraOffset;
    }

    void Update()
    {
        if (player.GetComponent<PlayerCombatMovement>().InCombat) IsInCombact();
        if (!player.GetComponent<PlayerCombatMovement>().InCombat) Iswalking();
        if (IsAiming && !player.GetComponent<PlayerCombatMovement>().InCombat) IsAimingTo();
        if (!IsAiming) MemoryValues();
    }
    void IsInCombact()
    {
        transform.position = target.transform.position;
        this.transform.rotation = target.transform.rotation;

    }
    void Iswalking()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationY += mouseX;
        rotationX += -mouseY;
        rotationX = Mathf.Clamp(rotationX, rotationXMinMax.x, rotationXMinMax.y);
        rotationY = Mathf.Clamp(rotationY, rotationYMinMax.x, rotationYMinMax.y);
        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.position = player.transform.position + CameraOffset - transform.forward * distanceFromTarget;
        transform.localEulerAngles = currentRotation;

    }
    void IsAimingTo()
    {
        //Stablisch the new camera position
        distanceFromTarget = 1;
        CameraOffset = new Vector3(0.35f, 1.4f, 0.5f);
        rotationXMinMax = new Vector2(-20f, 20f);
        rotationYMinMax = new Vector2(-20f, 30f);
        // Emulates camera rotation in Y axis
        Quaternion DesiredRotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x,
        this.transform.rotation.eulerAngles.y, player.transform.rotation.eulerAngles.z);
        player.transform.rotation = DesiredRotation;
    }
    void MemoryValues()
    {
        distanceFromTarget = distanceFromTargetMemory;
        CameraOffset = CameraOffsetMemory;
        rotationXMinMax = rotationXMinMaxMemory;
        rotationYMinMax = rotationYMinMaxMemory;
    }
}
