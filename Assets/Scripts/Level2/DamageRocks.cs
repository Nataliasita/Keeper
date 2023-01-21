using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRocks : MonoBehaviour
{
    GameObject player;

    void Start ()
    {
        player = GameObject.Find("PlayerComponents");
    }

    private void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerStats>().TakeDamage( 10f, true);
        }
    }
}
