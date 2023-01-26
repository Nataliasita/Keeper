using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsManager : MonoBehaviour
{
    public static StatsManager sharedInstance;
    [Header("Checkpoint")]
    public  Vector3 CheckPointPostion;


    [Header("GeneralStats")]
    public float MaxHealt;
    public float MaxDamage;
    public float MaxSpeed;
    public float Numberpoints;
    public float NumberpointsHealth;
    public float NumberpointsSpeed;
    public float especialShot1;
    public float especialShot2;

    [Header("CombatProgression")]
    public bool PowerAttack;
    public bool PowerAttack2;
    public bool PowerAttack3;
    public bool PowerAttack4;
    public bool MiniMap;
    public bool NigthVision;
    private CombatSystem combatSystem;

    [Header("LevelProgression")]

    public bool Level1Pass;
    public bool Level2Pass;
    public bool Level3Pass;

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
    private void Start()
    {
        combatSystem = GameObject.Find("PlayerComponents").GetComponent<CombatSystem>();
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
    public void AddPoints(int type, float pointsToAdd)
    {
        if (type == 1) Numberpoints += pointsToAdd;
        if (type == 2) NumberpointsHealth += pointsToAdd;
        if (type == 3) NumberpointsSpeed += pointsToAdd;
    }
    public void RemovePoints(int type, float pointsToRemove)
    {
        if (type == 1) Numberpoints += pointsToRemove;
        if (type == 2) NumberpointsHealth += pointsToRemove;
        if (type == 3) NumberpointsSpeed += pointsToRemove;
    }
    public void AddEspecialShot1(bool shotToAdd)
    {
        if (shotToAdd == true) especialShot1++;
        else especialShot1--;

    }
    public void RemoveEspecialShot2(bool shotToAdd)
    {
        if (shotToAdd == true) especialShot1++;
        else especialShot1--;
    }
    // Update is called once per frame
    private void Update()
    {
        if (PowerAttack) combatSystem.PowerAttack = true; else if (!PowerAttack) combatSystem.PowerAttack = false;
        if (PowerAttack2) combatSystem.PowerAttack2 = true; else if (!PowerAttack2) combatSystem.PowerAttack2 = false;
        if (PowerAttack3) combatSystem.PowerAttack3 = true; else if (!PowerAttack3) combatSystem.PowerAttack3 = false;
        if (PowerAttack4) combatSystem.PowerAttack4 = true; else if (!PowerAttack4) combatSystem.PowerAttack4 = false;
    }
}
