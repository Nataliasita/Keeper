using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightScript : MonoBehaviour
{
    public GameObject sigth;
    public int offsetX;
    public int offsetY;

    // Update is called once per frame
    void Update()
    {
        sigth.transform.position = new Vector3(Screen.width / 2 + offsetX, Screen.height / 2 + offsetY, 0);

        // Activación de la mira

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            sigth.gameObject.SetActive(true);
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            sigth.gameObject.SetActive(false);
        }
    }

}

