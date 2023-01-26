using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    public StatsManager statsManager;
    [Range(0.0f, 200)]
    public float Health;
    private Animator anim;
    private GameObject Player;
    private int lostScene;
    private void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        Player = this.gameObject;
        anim = GetComponent<Animator>();
        Player.transform.position = statsManager.CheckPointPostion;
    }
    private void Update()
    {
        if (Health <= 0)
        {
            GameManager.lostScene = SceneManager.GetActiveScene().buildIndex;
            GameManager.sharedInstance.GameOver();
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
    // public void SetCheckpoint(Vector3 NewPosition)
    // {
    //     statsManager.CheckPointPostion = NewPosition;
    // }
}
