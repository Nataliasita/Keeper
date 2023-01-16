using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMinimapcontroller : MonoBehaviour
{
    public GameObject Minimap;
    private bool active;
    // Start is called before the first frame update
    private void Start()
    {
        Minimap = GameObject.Find("PanelMinimap");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) DeactivateMiniMap();
    }
    public void DeactivateMiniMap()
    {
        active = !active;
        Minimap.SetActive(active);
    }
}

