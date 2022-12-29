using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCycle : MonoBehaviour
{
    public Material skyOne;
    public Material skyTwo;
    public Material skyThree;
    public Material skyFour;


    public void ChangeSkyBox(float valueGrade)
    {
        if(valueGrade >= 0)
        {
            RenderSettings.skybox = skyOne;
        }
        if( valueGrade >= 30)
        {
            RenderSettings.skybox = skyTwo;
        }
        if( valueGrade >= 150)
        {
            RenderSettings.skybox = skyThree;
        }
        if( valueGrade >= 185)
        {
            RenderSettings.skybox = skyFour;
        }
    }
}
