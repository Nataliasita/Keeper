using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualPanelCollectable : MonoBehaviour
{
    public GameObject ContextualPanel;
    public bool activeUIComponent;
    public int index;
    void Start()
    {
        ContextualPanel = GameObject.Find("ContextualPanel");
        Invoke("ClosePanel",.5f);
    }

    void ClosePanel()
    {
        ContextualPanel.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            ContextualPanel.SetActive(true);
            ContextualUIContentd.index = index;
        }
    }
}
