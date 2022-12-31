using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Mode")]
    public bool CanbeHurt;
    public GameObject EnemyPrefab;

    [Header("Enemy Stats")]
    [Range(0.0f, 100)]
    public float health;
    public bool IsAlive;
    public float trhust = 50;
    public Rigidbody rb;
    public GameObject Player;
    public bool RangeEnemy;
    public float weakpoints;
    public bool IsHurt;


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
        if (weakpoints >= 3 && !CanbeHurt)
        {
            this.gameObject.SetActive(false);
            Instantiate(EnemyPrefab, this.transform.position, this.transform.rotation);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(float damage, float trhustPotenciator)
    {
        IsHurt = true;
        rb.AddRelativeForce(Vector3.back * trhust * trhustPotenciator, ForceMode.Impulse);
        Invoke("IsNotHurt", 3.0f);
        if (CanbeHurt)
        {
            health -= damage;
            if (health <= 0)
            {
                IsAlive = false;
                this.gameObject.SetActive(false);
            }
        }
    }
    public void Attack()

    {
        if (RangeEnemy && !IsHurt)
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
        else if (!RangeEnemy && !IsHurt)
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
        transform.LookAt(Player.transform.position, Vector3.up);
        Quaternion projectileRot = Quaternion.identity;
        projectileRot.eulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, 0);
        Instantiate(projectile, this.transform.position, projectileRot);
    }
    public void MeeleEnemyAttack()
    {
        hitBox.SetActive(true);
        Invoke("DeactivateHitBox", 1.0f);
        if (Player.GetComponent<CombatSystem>().PlayerisParry == true)
        {
            TakeDamage(0, 1.5f);
            Player.GetComponent<CombatSystem>().blockingParry();
        }
        else
        {
            Player.GetComponent<PlayerStats>().TakeDamage(damagePlayer, true);
        }
    }
    public void DeactivateHitBox()
    {
        hitBox.SetActive(false);
    }
    public void IsNotHurt()
    {
        IsHurt = false;
    }
}
