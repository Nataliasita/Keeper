using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLava : MonoBehaviour
{
    GameObject player;

    void Start ()
    {
        player = GameObject.Find("PlayerComponents");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerStats>().TakeDamage( 2000f, true);
        }
    }
}
