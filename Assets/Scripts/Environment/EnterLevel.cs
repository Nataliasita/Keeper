using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager Manager;

    [SerializeField] bool lv1;
    [SerializeField] bool lv2;
    [SerializeField] bool lv3;

    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        // if (other.gameObject.CompareTag("Player") && lv2 == true)
        // {
            
        //     Manager.Level2();
        // }
        // if (other.gameObject.CompareTag("Player") && lv3 == true)
        // {
            
        //     Manager.Level3();
        // }

    }
}
