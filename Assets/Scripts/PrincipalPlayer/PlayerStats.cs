using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    public StatsManager statsManager;
    public GameManager gameManager; 
    [Range(0.0f, 200)]
    public float Health;
    private Animator anim;
    private GameObject Player;
    private void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        Player = this.gameObject;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        Player.transform.position = statsManager.CheckPointPostion;
    }
    private void Update()
    {
         
        if (Health <= 0)
        {
            gameManager.GameOver();
        }
   
    }
    public void TakeDamage(float damage, bool Candamage)
    {
        if (Candamage)
        {
            anim.SetTrigger("Hit");
            Health -= damage;
        }
    }
    public void Addlife(float life)
    {
        Health += life;
    }
     public void SetCheckpoint(Vector3 NewPosition)
    {
        statsManager.CheckPointPostion = NewPosition;
    }
}
