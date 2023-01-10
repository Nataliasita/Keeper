using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statsPanelFunctions : MonoBehaviour
{
    private StatsManager statsManager;
    public float healthIncrement;
    public float speedIncrement;
    public float damageIncrement;
    public float CorstIncrements;
    public float CorstIncreaseValue;
    public Animator anim;
    public GameObject canvasUI;
    public GameObject PowerUPcanvas;

    // Start is called before the first frame update
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
    }

    // Update is called once per frame
    public void AddHealth()
    {
        if (CorstIncrements < statsManager.Numberpoints)
        {
            statsManager.AddHealth(healthIncrement);
            statsManager.Numberpoints -= CorstIncrements;
            CorstIncrements += CorstIncreaseValue;
            anim.SetTrigger("Victory");
        }
        else
        {
            anim.SetTrigger("NotFounds");
        }
    }
    public void AddDamage()
    {
        if (CorstIncrements < statsManager.Numberpoints)
        {
            statsManager.AddDamage(damageIncrement);
            statsManager.Numberpoints -= CorstIncrements;
            CorstIncrements += CorstIncreaseValue;
            anim.SetTrigger("Victory");
        }
        else
        {
            anim.SetTrigger("NotFounds");
        }
    }
    public void AddSpeed()
    {
        if (CorstIncrements < statsManager.Numberpoints)
        {
            statsManager.AddSpeed(speedIncrement);
            statsManager.Numberpoints -= CorstIncrements;
            CorstIncrements += CorstIncreaseValue;
            anim.SetTrigger("Victory");
        }
        else
        {
            anim.SetTrigger("NotFounds");
        }
    }
    public void CloseWindow()
    {
        canvasUI.SetActive(true);
        PowerUPcanvas.SetActive(false);
    }
}
