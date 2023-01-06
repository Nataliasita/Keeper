using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{
    public GameObject sistPartBurbujas, vidrioVFX;

    public bool underWater;

    void Update()
    {
        if (underWater)
        {
            sistPartBurbujas.SetActive(true);
            RenderSettings.fog = true;
            RenderSettings.fogDensity = 0.01f;
            vidrioVFX.SetActive(true);
        }
        else
        {
            sistPartBurbujas.SetActive(false);
            RenderSettings.fog = false;
            vidrioVFX.SetActive(false);
        }
    }
}
