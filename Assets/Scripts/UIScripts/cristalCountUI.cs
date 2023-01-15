using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cristalCountUI : MonoBehaviour
{
    public float cristalCount;
    public bool IsSpeedCristal;
    public bool IsHealthCristal;
    public bool IsPowerCristal;
    [SerializeField] TextMeshProUGUI cristalCountNumberText;
    public StatsManager statsManager;
    // Start is called before the first frame update
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        cristalCountNumberText = GetComponent<TextMeshProUGUI>();
    }
    private void Update() 
    {
        if (IsSpeedCristal)
        {
            cristalCount = statsManager.Numberpoints;
            cristalCountNumberText.text = cristalCount.ToString("0");
        }
        if (IsHealthCristal)
        {
            cristalCount = statsManager.NumberpointsHealth;
            cristalCountNumberText.text = cristalCount.ToString("0");
        }
        if (IsPowerCristal)
        {
            cristalCount = statsManager.NumberpointsSpeed;
            cristalCountNumberText.text = cristalCount.ToString("0");
        }
    }
}

