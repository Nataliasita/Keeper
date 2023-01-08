using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCameraDetector : MonoBehaviour
{
    Camera PrincipalCamera;
    Camera miniMapCamera;
    MeshRenderer objectRenderer;
    Plane[] cameraFrustum;
    Plane[] cameraMinimapFrustum;
    Collider colliderDetector;
    void Start()
    {
        PrincipalCamera = Camera.main;
        miniMapCamera = GameObject.Find("CameraMiniMap").GetComponent<Camera>();
        objectRenderer = GetComponent<MeshRenderer>();
        colliderDetector = GetComponent<Collider>();
    }


    void Update()
    {
        var bounds = colliderDetector.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(PrincipalCamera);
        cameraMinimapFrustum = GeometryUtility.CalculateFrustumPlanes(miniMapCamera);

        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            objectRenderer.enabled = true;
        }
        else
        {
            objectRenderer.enabled = false;
        }
        if (GeometryUtility.TestPlanesAABB(cameraMinimapFrustum, bounds))
        {
            objectRenderer.enabled = true;
        }
    }
}
