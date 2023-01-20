using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBossEnemyElements : MonoBehaviour
{
    public BossEnemyStats enemyStats;
    public Camera my_camera;
    SpriteRenderer Spritecolor;
    public GameObject healthBar;
    private float MaxHealth;
    private float reductionUnit;
    private float localScaleX;

    void Start()
    {
        my_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        enemyStats = GetComponent<BossEnemyStats>();
        Spritecolor = healthBar.GetComponent<SpriteRenderer>();
        localScaleX = healthBar.transform.localScale.x;
        Spritecolor.color = Color.green;
        MaxHealth = GetComponent<BossEnemyStats>().MaxHealth;
    }
    void FixedUpdate()
    {
        if (enemyStats.health <= MaxHealth / 2) Spritecolor.color = Color.yellow;
        if (enemyStats.health <= MaxHealth / 4) Spritecolor.color = Color.red;
    }
    void Update()
    {
        // unidad de reduccion
        reductionUnit = localScaleX / MaxHealth;
        Billboard();
        healthBar.transform.localScale = new Vector3(reductionUnit * enemyStats.health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
    // Update is called once per frame
    void TakeDamage(float damage)
    {
        enemyStats.health -= damage;
    }
    void Billboard()
    {
        healthBar.transform.LookAt(healthBar.transform.position + my_camera.transform.rotation * Vector3.back,
        my_camera.transform.rotation * Vector3.up);
    }
}

