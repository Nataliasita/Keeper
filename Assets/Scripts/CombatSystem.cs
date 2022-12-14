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
    private PlayerCombatMovement PlayerMovement;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = GetComponent<PlayerCombatMovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
        if (enemyInAttackRange && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMovement.InCombat = true;
            enemyInRange = Physics.OverlapSphere(transform.position, attackRange, whatIsEnemy);
        }
        if (PlayerMovement.InCombat == true && Input.GetKeyDown(KeyCode.Q))
        {
            PlayerMovement.InCombat = false;
        }
        MeeleAttack();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void MeeleAttack()
    {
        if  (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");
        }
    }
}
