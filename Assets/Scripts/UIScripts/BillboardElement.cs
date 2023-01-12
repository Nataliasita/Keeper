using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardElement : MonoBehaviour
{
    public Camera my_camera;
    private GameObject spriteElement;
    // Start is called before the first frame update
    void Start()
    {
        my_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        spriteElement = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        spriteElement.transform.LookAt(spriteElement.transform.position + my_camera.transform.rotation * Vector3.back,
        my_camera.transform.rotation * Vector3.up);
    }
}
