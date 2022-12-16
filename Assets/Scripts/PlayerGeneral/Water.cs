using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject VolumenWater;


    private void OnTriggerEnter(Collider collider) {
        
        if(collider.CompareTag("Player"))
        {
            
            VolumenWater.SetActive(true);
        }
            
        }

}



