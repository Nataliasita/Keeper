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
    public Vector3 CameraOffset;
    public GameObject player;
    public GameObject target;

    void Update()
    {
        Iswalking();
        if (player.GetComponent<PlayerCombatMovement>().InCombat)
        {
            IsInCombact();
        }

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

        // Apply clamping for x rotation 

        rotationX = Mathf.Clamp(rotationX, rotationXMinMax.x, rotationXMinMax.y);
        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        // Apply damping between rotation changes

        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;

        // Substract forward vector of the GameObject to point its forward vector to the target
        transform.position = player.transform.position + CameraOffset - transform.forward * distanceFromTarget;
    }
}
