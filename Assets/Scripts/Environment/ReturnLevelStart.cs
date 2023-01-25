using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnLevelStart: MonoBehaviour
{

    public GameManager Manager;
    public StatsManager statsManager;

    public LevelBossFinal levelFinal;

    [SerializeField] bool keyLv1;
    [SerializeField] bool keyLv2;
    [SerializeField] bool keyLv3;

    LevelBossFinal levelBossFinal;

    public static int countKeys = 0;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && keyLv1 == true)
        {   
            countKeys += 1;
            Debug.Log(countKeys);
            if(countKeys == 3) InfoKeys.keyactive = countKeys;
            InfoKeys.passLevel1 = true;
            Manager.Game();
            
        }
        if (other.gameObject.CompareTag("Player") && keyLv2 == true)
        {   
            countKeys += 1;
            Debug.Log(countKeys);
            if(countKeys == 3) InfoKeys.keyactive = countKeys;
            InfoKeys.passLevel2 = true;
            Manager.Game();
            
        }
        if (other.gameObject.CompareTag("Player") && keyLv3 == true)
        {   
            countKeys += 1;
            Debug.Log(countKeys);
            if(countKeys == 3) InfoKeys.keyactive = countKeys;
            InfoKeys.passLevel3 = true;
            Manager.Game();
            
        }


    }


}
