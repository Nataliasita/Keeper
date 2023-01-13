using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterModeBattle : MonoBehaviour
{
    public GameManager Manager;

    [SerializeField] bool battle1;
    [SerializeField] bool battle2;
    [SerializeField] bool battle3;

    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && battle1 == true)
        {
            Manager.FightLevel1();
        }
        if (other.gameObject.CompareTag("Player") && battle2 == true)
        {
            
            Manager.FightLevel2();
        }
        if (other.gameObject.CompareTag("Player") && battle3 == true)
        {
            
            Manager.FightLevel3();
        }

    }
}
