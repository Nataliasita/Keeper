using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{
    public GameObject volumeOne, volumeTwo, particleBubbles;

    public bool underWater;

    void Update()
    {
        if (underWater)
        {
            volumeOne.SetActive(true);
            particleBubbles.SetActive(true);
            RenderSettings.fog = true;
            RenderSettings.fogDensity = 0.003f;
            volumeTwo.SetActive(true);
        }
        else
        {
            volumeOne.SetActive(false);
            RenderSettings.fog = false;
            volumeTwo.SetActive(false);
            particleBubbles.SetActive(false);
        }
    }
}
