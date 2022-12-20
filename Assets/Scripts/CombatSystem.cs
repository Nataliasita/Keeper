using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [Header("Attacking")]
    public Animator anim;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public Collider[] enemyInRange;
    public bool enemyInAttackRange;
    public float comboIndex = 0;
    private PlayerCombatMovement PlayerMovement;
    public GameObject Sword;
    public GameObject Anmo;

    [Header("Shotting")]
    public GameObject Camera;
    private FollowPlayer CameraController;
    public GameObject prefab;
    public GameObject Canon;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        CameraController = Camera.GetComponent<FollowPlayer>();
        PlayerMovement = GetComponent<PlayerCombatMovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MeeleAttackCombo();
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
        if (enemyInAttackRange && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMovement.EnemyIndex = 0;
            PlayerMovement.InCombat = true;
            Sword.SetActive(true);
            Anmo.SetActive(false);
            anim.SetBool("Aiming", false);
            CheckForEnemies();
        }
        if (PlayerMovement.InCombat == true && Input.GetKeyDown(KeyCode.Q))
        {
            PlayerMovement.InCombat = false;
            anim.SetBool("Aiming", false);
            Anmo.SetActive(false);
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
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void MeeleAttackCombo()
    {
        if (comboIndex > 0) comboIndex -= 0.5f * Time.deltaTime;

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
    private void DistanceAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !PlayerMovement.InCombat)
        {
            Anmo.SetActive(true);
            Sword.SetActive(false);
            Invoke("Shoot", 0.6f);
        }
    }
    private void Shoot()
    {
        Instantiate(prefab, Canon.transform.position + offset, Canon.transform.rotation);
    }
    public void CheckForEnemies()
    {
        enemyInRange = Physics.OverlapSphere(transform.position, attackRange, whatIsEnemy);

    }

}
