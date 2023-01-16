using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardRotate : MonoBehaviour
{
    public float rotationSpeed = 5;
    public bool life;
    public bool IsHealthCristal;
    public bool IsSpeedCristal;
    public bool IsPowerCristal;
    private StatsManager statsManager;
    public GameObject child;
    private MeshRenderer Mesh;
    private int RandomIndex;
    public Material materialHealth;
    public Material materialSpeed;
    public Material materialPower;
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        Mesh = child.GetComponent<MeshRenderer>();
        RandomIndex = Random.Range(1, 4);
    }
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
        if (!life)
        {

            if (RandomIndex == 1)
            {
                Mesh.material = materialHealth;
                IsHealthCristal = true;
            }
            if (RandomIndex == 2)
            {
                Mesh.material = materialSpeed;
                IsSpeedCristal = true;
            }
            if (RandomIndex == 3)
            {
                Mesh.material = materialPower;
                IsPowerCristal = true;
            }
        }
        if (life)
        {
            Mesh.material = materialSpeed;
            IsHealthCristal = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && !life)
        {
            if (IsPowerCristal) statsManager.AddPoints(1, 1);
            if (IsHealthCristal) statsManager.AddPoints(2, 1);
            if (IsSpeedCristal) statsManager.AddPoints(3, 1);
            Destroy(gameObject);

            // UI.CoinsCount += 1;
        }
        if (other.gameObject.CompareTag("Player") && life && other.gameObject.GetComponent<PlayerStats>().Health < statsManager.MaxHealt)
        {
            other.gameObject.GetComponent<PlayerStats>().Addlife(statsManager.MaxHealt / 4);
            Destroy(gameObject);
        }
    }
}
