using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    [Range(0.0f, 100)]
    public float health;
    public bool IsAlive;
    public float trhust = 50;
    public Rigidbody rb;
    public GameObject Player;
    public bool RangeEnemy;


    [Header("Attacking")]
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject hitBox;
    public float damagePlayer;
    public GameObject projectile;

    private void Start()
    {
        Player = GameObject.Find("PlayerComponents");
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(float damage)
    {
        rb.AddRelativeForce(Vector3.back * trhust, ForceMode.Impulse);
        health -= damage;
        
        if (health <= 0)
        {
            IsAlive = false;
            this.gameObject.SetActive(false);
        }
    }
    public void Attack()

    {
        if (RangeEnemy)
        {
            if (!alreadyAttacked)
            {
                ///Attack code here
                Shoot();
                ///End of attack code
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
        else if (!RangeEnemy)
        {
            if (!alreadyAttacked)
            {
                ///Attack code here
                MeeleEnemyAttack();
                ///End of attack code
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }
    public void Shoot()
    {
        Instantiate(projectile, this.transform.position, this.transform.rotation);
    }
    public void MeeleEnemyAttack()
    {
        hitBox.SetActive(true);
        Invoke("DeactivateHitBox", 1.0f);
    }
    public void DeactivateHitBox()
    {
        hitBox.SetActive(false);
        Player.GetComponent<PlayerStats>().TakeDamage(damagePlayer);
    }

}
