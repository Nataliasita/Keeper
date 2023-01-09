using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardRotate : MonoBehaviour
{
    public float rotationSpeed = 5;
    public bool life;
    //public coinsUI UI;
    void Start()
    {
        //UI = GameObject.Find("CoinsUI").GetComponent<coinsUI>();
    }
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Player") && !life)
        {
            Destroy(gameObject);
           // UI.CoinsCount += 1;
        }
        if (other.gameObject.CompareTag("Player") && life && other.gameObject.GetComponent<PlayerStats>().Health < 200)
        {
            other.gameObject.GetComponent<PlayerStats>().Addlife(50);
            Destroy(gameObject);
        }
    }
}
