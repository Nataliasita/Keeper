using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMiniMap : MonoBehaviour
{
    public GameObject Minimap;

    private bool active;
    public float duration;
    public FollowPlayer camerafollow;

    void Start()
    {
        Minimap = GameObject.Find("PanelMinimap");
        StartCoroutine(CameraFix(duration));
        camerafollow = GetComponent<FollowPlayer>();
        Minimap.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
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
