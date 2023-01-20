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
    public float MaxHealth;
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
    public float ShootOfset;

    [Header("Rewards")]
    public GameObject prefabReward;
    public GameObject prefabLife;
    public float rewardCuantity;
    public Animator anim;
    public Animator Outline;
    //private DetectorSensor Sensor;

    [Header("Changes Enemy")]
    public GameObject prefabSpirit;
    public GameObject prefabAnimal;

    private void Start()
    {
        MaxHealth = health;
        //Sensor = GameObject.Find("Sensor").GetComponent<DetectorSensor>();
        Player = GameObject.Find("PlayerComponents");
        rb = GetComponent<Rigidbody>();
        if (RangeShootEnemy) anim = GetComponent<Animator>();     
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
            transform.LookAt(Player.transform.position, Vector3.up);
            Quaternion projectileRot = Quaternion.identity;
            projectileRot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x - ShootOfset, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            Instantiate(projectile, this.transform.position, projectileRot);
            anim.SetTrigger("Attack");
            // Outline.SetTrigger("Attack");
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
        ChangeEnemyBasic();
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
        ChangeEnemyThrow();
        this.gameObject.SetActive(false);
        int index;
        Player.GetComponent<CombatSystem>().comboIndex = 0;
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

    //Changes enemies animals
    public void ChangeEnemyThrow()
    {   
        GameObject spirit = Instantiate(prefabSpirit, this.transform.position, Quaternion.identity);
        spirit.transform.LookAt(Player.transform.position, Vector3.up);
        Destroy (spirit , 2.5f);
        GameObject animal = Instantiate(prefabAnimal, this.transform.position, Quaternion.identity);
        animal.transform.LookAt(Player.transform.position, Vector3.up);
        Destroy (animal , 18f);
    }

    public void ChangeEnemyBasic()
    {   
        anim.SetTrigger("Attack");
    }
}
