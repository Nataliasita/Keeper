using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    public float weaponDamage;
    private Vector3 SpawnHere;
    public GameObject ParticleEffect;
    private GameObject player;
    public GameObject trialEffect;
    private void Start()
    {
        player = GameObject.Find("PlayerComponents");
    }
    private void Update()
    {

        if (player.GetComponent<CombatSystem>().comboIndex > 0)
        {
            trialEffect.SetActive(true);
        }
        else
        {
            trialEffect.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        SpawnHere = other.ClosestPoint(transform.position);

        if (other.gameObject.CompareTag("HitBox"))
        {
            Instantiate(ParticleEffect, SpawnHere, other.transform.rotation);
        }

        if (other.gameObject.CompareTag("Enemy") && player.GetComponent<CombatSystem>().comboIndex > 0)
        {
            Instantiate(ParticleEffect, SpawnHere, other.transform.rotation);
            other.gameObject.GetComponent<EnemyStats>().TakeDamage(weaponDamage, 1f);
        }
    }
}
