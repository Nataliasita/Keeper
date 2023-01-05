using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCameraDetector : MonoBehaviour
{
    Camera camera;
    MeshRenderer renderer;
    Plane[] cameraFrustum;
    Collider collider;
    void Start()
    {
        camera = Camera.main;
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();

    }

    
    void Update()
    {
        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);

        if( GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            renderer.enabled=true;
        }else
        {
            renderer.enabled=false;
            
        }
    }
}
