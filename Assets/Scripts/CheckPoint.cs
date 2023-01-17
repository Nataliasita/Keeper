using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckPoint : MonoBehaviour
{
    public StatsManager statsManager;
    public bool IsPortal;
    public Vector3  portalstartPoint;
    // Start is called before the first frame update
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !IsPortal)
        {
            statsManager.CheckPointPostion = this.gameObject.transform.position;
        }
        if (other.CompareTag("Player") && IsPortal)
        {
            statsManager.CheckPointPostion = portalstartPoint;
        }
    }
}
