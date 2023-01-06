using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMaterial : MonoBehaviour
{
    //Variables
    [Header("Movimiento")]
    public float desplazarX = 0.1f;
    public float desplazarY = 0.1f;

    void Update()
    {
        float offsetX = Time.time * desplazarX / 100;
        float offsetY = Time.time * desplazarY / 100; 
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
