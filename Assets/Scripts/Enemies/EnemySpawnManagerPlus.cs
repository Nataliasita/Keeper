using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManagerPlus : MonoBehaviour
{
    public EnemyStats enemyStats;
    public SpawnManager spawnManager;
    public bool CanCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(enemyStats.health <= 10 && !CanCount)
        {
            spawnManager.Deathcount ++;
            CanCount = true;
        }
    }
}
