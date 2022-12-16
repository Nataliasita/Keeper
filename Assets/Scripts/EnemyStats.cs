using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    [Range(0.0f, 100)]
    public float health;
    public float trhust = 50;
    public Rigidbody rb;
    public GameObject Player;
    public Vector3 lookPos;
    public float damping;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        lookPos = Player.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
       // transform.LookAt(Player.transform.position - offset, Vector3.up);
    }
    public void TakeDamage(float damage)
    {
        rb.AddRelativeForce(Vector3.back * trhust, ForceMode.Impulse);
        health -= damage;
    }
}
