using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaCycle : MonoBehaviour
{   
    public GameObject sea;
    public Material oceanDay;
    public Material oceanNight;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void ChangeOcean(float value)
    {
        Renderer rendSea = sea.GetComponent<Renderer>();
        if( value >= 185)
        {
            rendSea.material = oceanNight;
        }
        else
        {
            rendSea.material = oceanDay;
        }

    }
}
