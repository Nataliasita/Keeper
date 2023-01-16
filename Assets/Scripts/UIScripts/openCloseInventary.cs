using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCloseInventary : MonoBehaviour
{
    public GameObject inventary;
    private bool active;
    // Start is called before the first frame update
    private void Start()
    {
        inventary = GameObject.Find("Inventory");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) DeactivateInventary();

    }
    public void DeactivateInventary()
    {
        active = !active;
        inventary.SetActive(active);
    }
}

