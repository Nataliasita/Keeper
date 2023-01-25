using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager Manager;
    public InventaryManager Inventary;

    [SerializeField] bool lv1;
    [SerializeField] bool lv2;
    [SerializeField] bool lv3;

    void Start()
    {
        Inventary =  GameObject.Find("InventoryManager").GetComponent<InventaryManager>();
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        LevelChangeValidation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && lv1 == true)
        {
            Manager.Level1();
        }

        if (other.gameObject.CompareTag("Player") && lv2 == true)
        {
            
            Manager.Level2();
        }
        
        if (other.gameObject.CompareTag("Player") && lv3 == true)
        {
            
            Manager.Level3();
        }

    }

    private void LevelChangeValidation()
    {
       if(InfoKeys.passLevel1 == true) {
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
       }
       if(InfoKeys.passLevel2 == true) {
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
       }
        if(InfoKeys.passLevel3 == true) {
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
       }
    }
}
