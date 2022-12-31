using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;

    [Range(0.0f, 200.0f)]
    public float CurrentHealth;
    public float MaxHealt = 200f;
    public PlayerStats Player;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        Player = GameObject.Find("PlayerComponents").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Player.Health;
        healthBar.fillAmount = CurrentHealth / MaxHealt;
    }
}
