using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnLevelStart: MonoBehaviour
{

    public GameManager Manager;
    public StatsManager statsManager;

    [SerializeField] bool keyLv1;
    [SerializeField] bool keyLv2;
    [SerializeField] bool keyLv3;

    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && keyLv1 == true ||
            other.gameObject.CompareTag("Player") && keyLv2 == true ||
            other.gameObject.CompareTag("Player") && keyLv3 == true)
        {
            Manager.Game();
        }

    }
}
