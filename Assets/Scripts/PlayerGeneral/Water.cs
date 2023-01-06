using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider) {
        
        if(collider.CompareTag("Player"))
        {
            // Time.timeScale - 0.3f;
            
        }
            
        }


}



