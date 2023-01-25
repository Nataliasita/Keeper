using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSecundary : MonoBehaviour
{
    public GameObject activeKeyLevel;

    public EnemyStats enemyStats;


    void Start()
    {
        enemyStats = GameObject.Find("BossSecondary").GetComponent<EnemyStats>();
        // enemyStats = this.gameObject.GetComponent<EnemyStats>();
        activeKeyLevel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyStats.health == 0)
        {
            activateSectionKey();
        }
    }


    public void activateSectionKey()
    {
        activeKeyLevel.SetActive(true);
    }

    


}
