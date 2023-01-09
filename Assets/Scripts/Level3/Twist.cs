using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twist : MonoBehaviour
{
    private void OnTriggerStay(Collider collider) {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.transform.Rotate( 0.0f, 70.0f * Time.deltaTime, 0.0f);
        }

    }
}
