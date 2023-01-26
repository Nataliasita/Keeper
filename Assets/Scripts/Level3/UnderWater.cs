using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{
    public PlayerCombatMovement PlayerCombat;
    public GameObject volumeOne, volumeTwo, particleBubbles;
    public bool underWater;

    private void Start()
    {
        PlayerCombat = GameObject.Find("PlayerComponents").GetComponent<PlayerCombatMovement>();
    }
    void Update()
    {
        if (underWater)
        {
            volumeOne.SetActive(true);
            particleBubbles.SetActive(true);
            RenderSettings.fog = true;
            RenderSettings.fogDensity = 0.003f;
            volumeTwo.SetActive(true);
            SoundManager.Instance.Play(4);
        }
        else
        {
            volumeOne.SetActive(false);
            RenderSettings.fog = false;
            volumeTwo.SetActive(false);
            particleBubbles.SetActive(false);
        }
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            underWater = true;
            PlayerCombat.PlayerIsSwimming = true;
        }
    }
}
