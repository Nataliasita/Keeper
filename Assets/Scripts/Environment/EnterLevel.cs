using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager Manager;
    public InventaryManager Inventary;

    public StatsManager statsManager;

    [SerializeField] public bool lv1;
    [SerializeField] public bool lv2;
    [SerializeField] public bool lv3;





    void Start()
    {
        Inventary =  GameObject.Find("InventoryManager").GetComponent<InventaryManager>();
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        statsManager= GameObject.Find("StatsManager").GetComponent<StatsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lv1){
            if(statsManager.Level1Pass)
            {
                this.gameObject.SetActive(false);
            }else if(!statsManager.Level1Pass)
            {
                this.gameObject.SetActive(true);    
            }
        }
        
        if(lv2)
        {
                if(statsManager.Level2Pass)
            {
                this.gameObject.SetActive(false);
            }else if(!statsManager.Level2Pass)
            {
                this.gameObject.SetActive(true);    
            }
        }
        
        
        if(lv3)
        {
            if(statsManager.Level3Pass)
            {
                this.gameObject.SetActive(false);

            }else if(!statsManager.Level3Pass)
            {
                this.gameObject.SetActive(true);    
            }
        }
        Debug.Log(statsManager.Level2Pass);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && lv1 == true)
        {   
            Manager.Level1();
            // StatsManager.sharedInstance.Level1Pass = true;
        }

        if (other.gameObject.CompareTag("Player") && lv2 == true)
        {
            
            Manager.Level2();
            // StatsManager.sharedInstance.Level2Pass = true;
           
        }
        
        if (other.gameObject.CompareTag("Player") && lv3 == true)
        {   
            Manager.Level3();
            // StatsManager.sharedInstance.Level3Pass = true;
        }

    }

    // private void LevelChangeValidation()
    // {
    //    if(InfoKeys.passLevel1 == true) {
    //         this.gameObject.GetComponent<SphereCollider>().enabled = false;
    //    }
    //    if(InfoKeys.passLevel2 == true) {
    //         this.gameObject.GetComponent<SphereCollider>().enabled = false;
    //    }
    //     if(InfoKeys.passLevel3 == true && lv2) {
    //         this.gameObject.GetComponent<SphereCollider>().enabled = false;
    //    }
    // }
}
