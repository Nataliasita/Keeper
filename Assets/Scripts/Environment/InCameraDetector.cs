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
    MeshCollider colliderMeshDetector;
    public bool isMesh;
    void Start()
    {
        PrincipalCamera = Camera.main;
        miniMapCamera = GameObject.Find("CameraMiniMap").GetComponent<Camera>();
        objectRenderer = GetComponent<MeshRenderer>();
        if (isMesh)
        {
            colliderMeshDetector = GetComponent<MeshCollider>();
        }
        if (!isMesh)
        {
            colliderDetector = GetComponent<Collider>();
        }
    }


    void Update()
    {
        if (isMesh)
        {
            var bounds = colliderMeshDetector.bounds;
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
        if (!isMesh)
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
}
