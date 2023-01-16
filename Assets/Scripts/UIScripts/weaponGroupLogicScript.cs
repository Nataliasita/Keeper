using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponGroupLogicScript : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public StatsManager statsManager;

    // Start is called before the first frame update
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!statsManager.PowerAttack)
        {
            Panel2.SetActive(false);
            Panel3.SetActive(false);
        }
        if (statsManager.PowerAttack)
        {
            Panel1.SetActive(false);

            if (Input.GetKey(KeyCode.Mouse1))
            {
                Panel2.SetActive(true);
                Panel3.SetActive(false);
            }
            else
            {
                Panel2.SetActive(false);
                Panel3.SetActive(true);
            }
        }
    }
}
