using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool AreaDamageProjectile;
    public bool freeezingProjectile;
    public float Lifetime = 8f;
    public float coutdown = 5f;
    public float speed = 20f;
    public float damage = 5;
    public float gravity;
    private Rigidbody rb;
    public bool ally;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coutdown = Lifetime;
        rb.velocity = speed * transform.forward;
    }

    void Update()
    {
        coutdown -= Time.deltaTime;
        if (coutdown <= 0f)
        {
            Destroy(gameObject);
        }
        rb.AddRelativeForce(Vector3.down * gravity , ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !ally)
        {
            if (other.GetComponent<CombatSystem>().PlayerisParry == false)
            {
                other.GetComponent<PlayerStats>().TakeDamage(damage, true);
                Destroy(gameObject);
            }
            else
            {
                other.GetComponent<PlayerStats>().TakeDamage(damage, false);
                other.GetComponent<CombatSystem>().blockingParry();
                rb.velocity = Vector3.zero;
                rb.AddRelativeForce(Vector3.back * speed * 1.2f, ForceMode.VelocityChange);
                ally = true;
            }
        }
        if (other.CompareTag("Ground") && ally)
        {
            rb.isKinematic = true;
        }
        if (other.CompareTag("Enemy") && ally)
        {
            if (freeezingProjectile)
            {

            }
            if (AreaDamageProjectile)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
            if (!AreaDamageProjectile && !freeezingProjectile)
            {
                other.GetComponent<EnemyStats>().TakeDamage(damage, 1);
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("BossEnemy") && ally)
        {
            if (freeezingProjectile)
            {

            }
            if (AreaDamageProjectile)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
            if (!AreaDamageProjectile && !freeezingProjectile)
            {
                other.GetComponent<BossEnemyStats>().TakeDamage(damage, 1);
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("WeakPoint") && ally)
        {
            other.transform.parent.GetComponent<EnemyStats>().weakpoints += 1;
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Enemy") && AreaDamageProjectile)
        {
            other.GetComponent<EnemyStats>().TakeDamage(damage / 5, 0);
            this.gameObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime;
        }
         if (other.CompareTag("BossEnemy") && AreaDamageProjectile)
        {
            other.GetComponent<BossEnemyStats>().TakeDamage(damage / 5, 0);
            this.gameObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime;
        }
        if (other.CompareTag("Ground") && AreaDamageProjectile)
        {
            this.gameObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * 1.5f;
        }
    }

}
