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
    private DetectorSensor Sensor;
    public bool ally;
    // Start is called before the first frame update
    void Start()
    {
        Sensor = GameObject.Find("Sensor").GetComponent<DetectorSensor>();
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
                rb.AddRelativeForce(Vector3.back * speed * 1.2f , ForceMode.VelocityChange);
                ally = true;
            }
        }
        if (other.CompareTag("Enemy") && ally)
        {
            other.GetComponent<EnemyStats>().TakeDamage(damage, 1);
            Destroy(gameObject);
        }
        if (other.CompareTag("WeakPoint") && ally)
        {
            other.transform.parent.GetComponent<EnemyStats>().weakpoints += 1;
            Sensor.RemoveEnemies(other.gameObject);
            Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

}
