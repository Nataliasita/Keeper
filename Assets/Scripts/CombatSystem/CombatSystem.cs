using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombatSystem : MonoBehaviour
{
    [Header("CombatProgression")]
    public bool PowerAttack;
    public bool PowerAttack2;
    public bool PowerAttack3;
    public bool PowerAttack4;
    public bool AreaDamageProjectile;
    public bool freeezingProjectile;
    [Header("Attacking")]
    public Animator anim;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public bool enemyInAttackRange;
    public float comboIndex = 0;
    private PlayerCombatMovement PlayerMovement;
    public GameObject Sword;
    public GameObject Anmo;

    [Header("Shotting")]
    public GameObject Camera;
    private FollowPlayer CameraController;
    public GameObject prefab;
    public GameObject Areaprefab;
    public GameObject Freezeprefab;
    public GameObject Canon;
    public Vector3 offset;
    public bool PlayerisParry;
    private StatsManager statsManager;
    // Start is called before the first frame update
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        CameraController = Camera.GetComponent<FollowPlayer>();
        PlayerMovement = GetComponent<PlayerCombatMovement>();
        anim = GetComponent<Animator>();
        Sword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MeeleAttackCombo();
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
        if (enemyInAttackRange && Input.GetKeyDown(KeyCode.R))
        {
            PlayerMovement.EnemyIndex = 0;
            PlayerMovement.InCombat = true;
            Sword.SetActive(true);
            Anmo.SetActive(false);
            anim.SetBool("Aiming", false);
        }
        if (PlayerMovement.InCombat == true && Input.GetKeyDown(KeyCode.Q))
        {
            PlayerMovement.InCombat = false;
            anim.SetBool("Aiming", false);
            Anmo.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Mouse1) && PlayerMovement.InCombat && PowerAttack2)
        {
            Sword.SetActive(true);
            anim.SetBool("Parry", true);
            PlayerisParry = true;
        }
        else
        {
            anim.SetBool("Parry", false);
            PlayerisParry = false;
        }
        if (Input.GetKey(KeyCode.Mouse1) && !PlayerMovement.InCombat)
        {
            Sword.SetActive(false);
            CameraController.IsAiming = true;
            anim.SetBool("Aiming", true);
            DistanceAttack();
            Anmo.SetActive(true);
        }
        else
        {
            CameraController.IsAiming = false;
            anim.SetBool("Aiming", false);
            Anmo.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            AreaDamageProjectile = false;
            freeezingProjectile = false;
        }
        if (Input.GetKey(KeyCode.Alpha2) && PowerAttack3)
        {
            AreaDamageProjectile = true;
            freeezingProjectile = false;
        }
        if (Input.GetKey(KeyCode.Alpha3) && PowerAttack4)
        {
            AreaDamageProjectile = false;
            freeezingProjectile = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void MeeleAttackCombo()
    {
        if (PowerAttack)
        {
            if (comboIndex > 0) comboIndex -= 0.58f * Time.deltaTime;

            if (comboIndex > 4)
            {
                comboIndex = 0;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Sword.SetActive(true);
                comboIndex += 0.7f;
            }

            anim.SetFloat("Attack", comboIndex);
        }
        else
        {
            comboIndex = 0;
            Sword.SetActive(false);
        }


    }
    private void DistanceAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !PlayerMovement.InCombat)
        {
            Anmo.SetActive(true);
            Sword.SetActive(false);
            anim.SetTrigger("Shoot");
            Invoke("Shoot", 0.6f);
        }
    }
    private void Shoot()
    {
        if (AreaDamageProjectile)
        {
            if (statsManager.especialShot1 > 0)
            {
                Instantiate(Areaprefab, Canon.transform.position + offset, Canon.transform.rotation);
                statsManager.especialShot1--;
            }
            else Instantiate(prefab, Canon.transform.position + offset, Canon.transform.rotation);
        }
        else if (freeezingProjectile && statsManager.especialShot2 > 0)
        {
            if (statsManager.especialShot2 > 0)
            {
                Instantiate(Freezeprefab, Canon.transform.position + offset, Canon.transform.rotation);
                statsManager.especialShot2--;
            }
            else Instantiate(prefab, Canon.transform.position + offset, Canon.transform.rotation);
        }
        else
        {
            Instantiate(prefab, Canon.transform.position + offset, Canon.transform.rotation);
        }
    }
    public void blockingParry()
    {
        anim.SetTrigger("BlockingParry");
    }

}
