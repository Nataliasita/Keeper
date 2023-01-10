using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Mode")]
    public bool CanbeHurt;
    public bool RangeShootEnemy;
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

    [Header("Rewards")]
    public GameObject prefabReward;
    public GameObject prefabLife;
    public float rewardCuantity;
    //private DetectorSensor Sensor;

    private void Start()
    {
        //Sensor = GameObject.Find("Sensor").GetComponent<DetectorSensor>();
        Player = GameObject.Find("PlayerComponents");
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!RangeShootEnemy)
        {
            if (weakpoints >= 3)
            {
                Instantiate(EnemyPrefab, this.transform.position, this.transform.rotation);
                //Sensor.RemoveEnemies(this.gameObject);
                this.gameObject.SetActive(false);
            }
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
                DeadEnemy();
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
        if (RangeShootEnemy)
        {
            transform.LookAt(Player.transform.position);
            Instantiate(projectile, this.transform.position, this.transform.rotation);
        }
        else
        {
            transform.LookAt(Player.transform.position, Vector3.up);
            Quaternion projectileRot = Quaternion.identity;
            projectileRot.eulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, 0);
            Instantiate(projectile, this.transform.position, projectileRot);
        }
    }
    public void MeeleEnemyAttack()
    {
        hitBox.SetActive(true);
        Invoke("DeactivateHitBox", 1.0f);
        if (Player.GetComponent<CombatSystem>().PlayerisParry == true)
        {
            TakeDamage(0, 1.7f);
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
    public void DeadEnemy()
    {
        IsAlive = false;
        this.gameObject.SetActive(false);
        int index;
        index = Random.Range(1, 5);
        if (index == 3)
        {
            Instantiate(prefabLife, this.transform.position, Quaternion.identity);
        }
        for (int i = 0; i < rewardCuantity; i++)
        {
            Vector3 posInicial = new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(0f, 2f), transform.position.z + Random.Range(-2f, 2f));
            Instantiate(prefabReward, posInicial, Quaternion.identity);
            prefabReward.GetComponent<Rigidbody>().AddForce(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f, 4f), ForceMode.Impulse);
        }
    }
}
