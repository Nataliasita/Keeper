using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterModeBattle : MonoBehaviour
{
    public GameObject visionNight;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            visionNight.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            visionNight.SetActive(true);
        }
    }
}
