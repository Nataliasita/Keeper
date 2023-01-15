using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underWaterVariant : MonoBehaviour
{
    public PlayerCombatMovement PlayerCombat;
    void Start()
    {
        PlayerCombat = GameObject.Find("PlayerComponents").GetComponent<PlayerCombatMovement>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerCombat.PlayerIsSwimming = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerCombat.PlayerIsSwimming = false;
            PlayerCombat.playerSpeed = 8f;
            PlayerCombat.jumpForce = 2.5f;
            PlayerCombat.gravityValue = -12f;
        }

    }
}
