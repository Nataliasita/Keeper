using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] Spawners;
    public float Deathcount;
    [SerializeField] int Index;
    [SerializeField] float DeathLimits;
    [SerializeField] float ActivationInterval = 5;
    private float ActivationMemory;
    public bool spawnersActive;
    public bool TaskComplete;

    void Start()
    {
        ActivationMemory = ActivationInterval;
    }
    void Update()
    {
        ActivationInterval -= 1 * Time.deltaTime;
        if (Deathcount <= DeathLimits && spawnersActive == true && ActivationInterval <= 0)
        {
            ActivateSpawner();
            ActivationInterval = ActivationMemory;
        }
        if (Deathcount >= DeathLimits)
        {
            spawnersActive = false;
            DesactivateSpawner();
            TaskComplete = true;
        }
        if (TaskComplete)
        {
            for (int i = 0; i < Spawners.Length; i++)
            {
                 Spawners[i].SetActive(false);
                 
            }
        }
    }
    void DesactivateSpawner()
    {
        Index = Random.Range(0, Spawners.Length);
        Spawners[Index].SetActive(false);
    }
    void ActivateSpawner()
    {
        Index = Random.Range(0, Spawners.Length);
        Spawners[Index].SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawnersActive = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && TaskComplete == false)
        {
            spawnersActive = true;
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && TaskComplete == true)
        {
            // Instantiate(Reward, this.transform.position, this.transform.rotation);
        }
    }
}
