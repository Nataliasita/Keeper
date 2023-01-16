using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progresionUIVisibility : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UIelement;
    public GameObject UIelement2;
    public GameObject UIelement3;
    public StatsManager statsManager;
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        UIelement = GameObject.Find("ButtonMap");
        UIelement2 = GameObject.Find("Group 1");
        UIelement3 = GameObject.Find("Group 2");
        UIelement.SetActive(false);
        UIelement2.SetActive(false);
        UIelement3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (statsManager.MiniMap) UIelement.SetActive(true);
        if (statsManager.PowerAttack3) UIelement2.SetActive(true);
        if (statsManager.PowerAttack4) UIelement3.SetActive(true);
    }
}
