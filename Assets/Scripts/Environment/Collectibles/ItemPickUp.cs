using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;
    [Header("itemIdentity")]
    StatsManager statsManager;
    [SerializeField] bool PowerAttack;
    [SerializeField] bool PowerAttack2;
    [SerializeField] bool PowerAttack3;
    [SerializeField] bool PowerAttack4;
    [SerializeField] bool MiniMap;
    [SerializeField] bool NigthVision;
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
    }
    void Pickup()
    {
        InventaryManager.sharedInstance.Add(Item);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("Player"))
        {
            Pickup();
            if (PowerAttack)statsManager.PowerAttack = true;
            if (PowerAttack2)statsManager.PowerAttack2 = true;
            if (PowerAttack3)statsManager.PowerAttack3 = true;
            if (PowerAttack4)statsManager.PowerAttack4 = true;
            if (MiniMap)statsManager.MiniMap = true;
            if (NigthVision)statsManager.NigthVision = true;
        }

    }
}
