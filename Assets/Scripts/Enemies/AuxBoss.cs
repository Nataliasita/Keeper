using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxBoss : MonoBehaviour
{
    public GameObject bossSecundary;

    public GameObject activeKeyLevel;



    private void Start() {
        Invoke("NewBossEnter", 60f);
        
    }
    public void NewBossEnter()
    {
        bossSecundary.SetActive(true);
        Invoke("ActiveLevel", 120f);
    }

    public void ActiveLevel()
    {       
        if(bossSecundary.GetComponent<EnemyStats>().health <= 0)
        {
            activeKeyLevel.SetActive(true);
        }

    }



    


}
