using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorSensor : MonoBehaviour
{
    public List<GameObject> enemyInRange = new List<GameObject>();
    private PlayerCombatMovement PlayerMovement;
    // Start is called before the first frame update
    void Start()
    {
         PlayerMovement = GameObject.Find("PlayerComponents").GetComponent<PlayerCombatMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && PlayerMovement.InCombat == false)
            enemyInRange.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && PlayerMovement.InCombat == false)
            enemyInRange.Remove(other.gameObject);
    }
    public void RemoveEnemies(GameObject EnemiesToRemove)
    {
        enemyInRange.Remove(EnemiesToRemove);
    }
}
