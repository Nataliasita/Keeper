using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Range(0.0f, 200)]
    public float Health;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("You are Dead");
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
}
