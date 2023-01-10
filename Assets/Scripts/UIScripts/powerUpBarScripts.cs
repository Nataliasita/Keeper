using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class powerUpBarScripts : MonoBehaviour
{
    private Image StatsBar;
    public float MaxValue;
    public float currentValue;
    public bool speedBar;
    public bool damageBar;
    public bool healthBar;
    private StatsManager statsManager;

    // Start is called before the first frame update
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        StatsBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speedBar)
        {
            currentValue = statsManager.MaxSpeed;
        }
        if (damageBar)
        {
            currentValue = statsManager.MaxDamage;
        }
        if (healthBar)
        {
            currentValue = statsManager.MaxHealt;
        }
        
        StatsBar.fillAmount = currentValue / MaxValue;
    }
}
