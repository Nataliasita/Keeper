using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBossFinal : MonoBehaviour
{
    public GameManager Manager;

    [SerializeField] bool allKeys;
    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && allKeys == true)
        {
            Manager.FightBoss();
        }

    }
}
