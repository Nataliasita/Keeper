using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Lifetime = 8f;
    public float coutdown = 5f;
    public float speed = 20f;
    public float damage = 5;
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
    }
    private void OnTriggerEnter(Collider other)
    {
        //PlayerStats player = other.gameObject.GetComponent<PlayerStats>();

        if (other.CompareTag("Player") && !ally)
        {
           // player.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy") && ally)
        {
            other.GetComponent<EnemyStats>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
