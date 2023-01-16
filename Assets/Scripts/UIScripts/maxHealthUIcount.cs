using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class maxHealthUIcount : MonoBehaviour
{
    public float MaxHealth;
    public StatsManager statsManager;
     [SerializeField] TextMeshProUGUI textHealth;
    // Start is called before the first frame update
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        textHealth = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        MaxHealth = statsManager.MaxHealt;
        textHealth.text = MaxHealth.ToString("0");
    }
}
