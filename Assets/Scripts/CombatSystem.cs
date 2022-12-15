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
    // Start is called before the first frame update
    void Start()
    {
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
            PlayerMovement.InCombat = true;
            enemyInRange = Physics.OverlapSphere(transform.position, attackRange, whatIsEnemy);
        }
        if (PlayerMovement.InCombat == true && Input.GetKeyDown(KeyCode.Q))
        {
            PlayerMovement.InCombat = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void MeeleAttackCombo()
    {
        Debug.Log(comboIndex);

        if (comboIndex > 0) comboIndex -= 0.5f * Time.deltaTime;

        if (comboIndex > 4)
        {
            comboIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            comboIndex += 0.7f;
        }

        anim.SetFloat("Attack", comboIndex);
    }
}
