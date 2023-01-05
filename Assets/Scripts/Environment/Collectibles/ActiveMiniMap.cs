using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMiniMap : MonoBehaviour
{
    public GameObject Minimap;

    private bool active;

    void Start() {
        
    }
    void Update() 
    {
        if(Input.GetKeyUp(KeyCode.M))
        {   
            active =! active;
            Minimap.SetActive(active);
        }
        
        Minimap.SetActive(active);
    }
}
