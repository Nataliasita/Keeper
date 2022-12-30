using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTemple : MonoBehaviour
{
    public GameObject GroupLigths;
    private void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player"))
        {
            GroupLigths.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider) {
        if(collider.CompareTag("Player"))
        {
            GroupLigths.SetActive(false);
        }
    }
}
