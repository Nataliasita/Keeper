using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardRotate : MonoBehaviour
{
    public float rotationSpeed = 5;
    public bool life;
    private StatsManager statsManager;
    
    public bool IsSpeedCristal;
    public bool IsHealthCristal;
    public bool IsPowerCristal;

    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
    }
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Player") && !life)
        {
            if(IsPowerCristal) statsManager.AddPoints(1,1);
            if(IsHealthCristal) statsManager.AddPoints(2,1);
            if(IsSpeedCristal) statsManager.AddPoints(3,1);
            Destroy(gameObject);
            
           // UI.CoinsCount += 1;
        }
        if (other.gameObject.CompareTag("Player") && life && other.gameObject.GetComponent<PlayerStats>().Health < statsManager.MaxHealt)
        {
            other.gameObject.GetComponent<PlayerStats>().Addlife(statsManager.MaxHealt/4);
            Destroy(gameObject);
        }
    }
}
