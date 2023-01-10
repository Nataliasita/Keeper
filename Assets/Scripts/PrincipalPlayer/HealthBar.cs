using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float MaxHealt;
    public float CurrentHealth;
    public PlayerStats Player;
    private StatsManager statsManager;

    // Start is called before the first frame update
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        healthBar = GetComponent<Image>();
        Player = GameObject.Find("PlayerComponents").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        MaxHealt = statsManager.MaxHealt;
        CurrentHealth = Player.Health;
        healthBar.fillAmount = CurrentHealth / MaxHealt;
    }
}
