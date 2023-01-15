using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public StatsManager statsManager;
    private MeshRenderer Mesh;
    // Start is called before the first frame update
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        Mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            statsManager.CheckPointPostion = this.gameObject.transform.position;
            Mesh.enabled = !Mesh.enabled;
        }
    }
}
