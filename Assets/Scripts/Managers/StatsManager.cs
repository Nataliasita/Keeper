using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager sharedInstance;
    public float MaxHealt;
    public float MaxDamage;
    public float MaxSpeed;
    public float Numberpoints;
    public float especialShot1;
    public float especialShot2;
     public void Awake()
    {
        // que despierte y enfatizo con el siguiente fragmento
        // Singleton
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    public void AddHealth(float healtToAdd)
    {
        MaxHealt += healtToAdd;
    }
     public void AddDamage(float DamageToAdd)
    {
        MaxDamage += DamageToAdd;
    }
    public void AddSpeed(float speedToAdd)
    {
        MaxSpeed += speedToAdd;
    }
     public void AddPoints(float pointsToAdd)
    {
        Numberpoints += pointsToAdd;
    }
    public void RemovePoints(float pointsToRemove)
    {
        Numberpoints -= pointsToRemove;
    }
    public void AddEspecialShot1(bool shotToAdd)
    {
          if (shotToAdd == true)especialShot1 ++ ;
          else especialShot1 --;
            
    }
     public void RemoveEspecialShot2(bool shotToAdd)
    {
          if (shotToAdd == true)especialShot1 ++ ;
          else especialShot1 --;
    }
    // Update is called once per frame
}
