using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMiniMap : MonoBehaviour
{
    public GameObject Minimap;
    StatsManager statsManager;
    private bool active;
    public float duration;
    public FollowPlayer camerafollow;

    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        Minimap = GameObject.Find("PanelMinimap");
        StartCoroutine(CameraFix(duration));
        camerafollow = GetComponent<FollowPlayer>();
        Minimap.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M) && statsManager.MiniMap == true)
        {
            active = !active;
            Minimap.SetActive(active);
        }

        Minimap.SetActive(active);
    }
    IEnumerator CameraFix(float duration)
    {
        float time = 0;
        while (time < duration)
        {
            camerafollow.enabled = false;
            time += Time.deltaTime;
            yield return null;
        }
        camerafollow.enabled = true;
    }
}
