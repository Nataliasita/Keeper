using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyStats : MonoBehaviour
{
    [Header("Enemy Mode")]
    public bool CanbeHurt;
    public GameObject EnemyPrefab;
    public Vector3 ProjectileRotation;
    public Vector3 ProjectileOffset;
    public GameObject projectile;
    public GameObject projectileVariant;

    public Light powerAttackLight;

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
    public Vector3 ShootOfset;

    [Header("Rewards")]
    public GameObject prefabReward;
    public GameObject prefabLife;
    public float rewardCuantity;
    public Animator anim;
    public GameManager Manager;
    //private DetectorSensor Sensor;

    private void Start()
    {
        MaxHealth = health;
        Player = GameObject.Find("PlayerComponents");
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        powerAttackLight.enabled = false;
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {

        if (weakpoints >= 3)
        {
            Instantiate(EnemyPrefab, this.transform.position, this.transform.rotation);
            this.gameObject.SetActive(false);
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
        powerAttackLight.enabled = true;
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
        int index;
        index = Random.Range(1, 5);
        if (index == 3)
        {   
            transform.LookAt(Player.transform.position, Vector3.up);
            Quaternion projectileRot = Quaternion.identity;
            projectileRot.eulerAngles = ProjectileRotation;
            Instantiate(projectile, this.transform.position + ProjectileOffset, projectileRot);
            anim.SetTrigger("AttackRadial"); 
        }
        if (index == 2)
        {
            for (int i = 0; i < 4; i++)
            {
                Invoke("MultipleShoots", .25f);
            }
        }
        if (index == 1)
        {
            GetComponent<BossFigthEnemyIA>().ChasePlayer();
        }
        if (index == 4)
        {
            transform.LookAt(Player.transform.position, Vector3.up);
            anim.SetTrigger("AttackProyectile");
            Instantiate(projectileVariant, this.transform.position + ShootOfset, this.transform.rotation);

        }
    }
    public void MultipleShoots()
    {
        transform.LookAt(Player.transform.position, Vector3.up);
        anim.SetTrigger("AttackProyectile");
        Instantiate(projectileVariant, this.transform.position + ShootOfset, this.transform.rotation);
    }
    public void MeeleEnemyAttack()
    {
        hitBox.SetActive(true);
        anim.SetTrigger("AttackHitbox");
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
        powerAttackLight.enabled = false;
    }
    public void DeadEnemy()
    {
        IsAlive = false;
        this.gameObject.SetActive(false);
        Manager.Win();
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
}

