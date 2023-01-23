using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWater : MonoBehaviour
{
    public int rutine;
    public float time;
    public Animator animEnemy;
    public Quaternion angle;
    public float grade;

    public bool inAttack;

    public GameObject target;
    public float health;
    public bool IsAlive;
    float damage = 5f;

    [Header("Rewards")]
    public Vector3 OffsetAparition = new Vector3(0, 0, 0);

    [Header("Changes Enemy")]
    public GameObject prefabSpirit;
    public GameObject prefabAnimal;
    public GameObject prefabAttack;

    private void Start() 
    {
        health = 100f;
        animEnemy = GetComponent<Animator>();
        target = GameObject.Find("PlayerComponents"); 
        prefabAttack.SetActive(false);  
    }

    private void Update() {
        BehaviorEnemy();
    }

    public void BehaviorEnemy()
    {
        if( Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            time += 1 * Time.deltaTime;

        if(time >= 4)
        {
            rutine = Random.Range(0,2);
            time = 0;

        }
        switch(rutine)
            {
                case 0:
                    animEnemy.SetBool("Walk", false);
                    break;
                case 1:
                    grade = Random.Range(0,360);
                    angle= Quaternion.Euler(0, grade,0);
                    rutine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    animEnemy.SetBool("Walk", true);
                    break;
            }

        }
        else
        {

            if(Vector3.Distance(transform.position, target.transform.position) > 1 && !inAttack)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                transform.Translate(Vector3.forward  * 2 * Time.deltaTime);
                animEnemy.SetBool("Attack", false);
            }
            else{
                animEnemy.SetBool("Walk", false);
            }
            
        }

    }

    public void Final_Anim()
    {
        animEnemy.SetBool("Attack", false);
        prefabAttack.SetActive(false);  
        inAttack = false;
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player"))
        {
            inAttack = true;
            animEnemy.SetBool("Attack", true);
            prefabAttack.SetActive(true);
            target.GetComponent<PlayerStats>().TakeDamage( 10f, true);
            this.gameObject.transform.LookAt(target.transform.position, Vector3.up);
        }
        if(other.CompareTag("Proyectile"))
        {
            health -= damage;
            if (health <= 0)
            {
                DeadEnemy();
            }
        }
    }

    public void DeadEnemy()
    {
        IsAlive = false;
        ChangeEnemyThrow();
        this.gameObject.SetActive(false);
    }

    public void ChangeEnemyThrow()
    {
        GameObject spirit = Instantiate(prefabSpirit, this.transform.position + OffsetAparition, Quaternion.identity);
        spirit.transform.LookAt(target.transform.position, Vector3.up);
        Destroy(spirit, 2.5f);
        GameObject animal = Instantiate(prefabAnimal, this.transform.position - OffsetAparition, Quaternion.identity);
        animal.transform.LookAt(target.transform.position, Vector3.up);
        Destroy(animal, 18f);
    }


}
