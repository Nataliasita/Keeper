using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBossFinal : MonoBehaviour
{
    public GameManager Manager;

    [SerializeField] public bool allKeys;

    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    private void Update() {

        Changekeys();
    }

    public void Changekeys(){
        if (InfoKeys.keyactive == 3)
        {
            allKeys = true; 
            Debug.Log("all keys");
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
        
    } 

    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && allKeys)
        {
            Manager.FightBoss();
        }

    }
}
