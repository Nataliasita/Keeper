using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorSensor : MonoBehaviour
{
    public List<GameObject> enemyInRange = new List<GameObject>();
    private PlayerCombatMovement PlayerMovement;
    // Start is called before the first frame update
    public int Count;
    private SphereCollider myCollider;
    public float RadiusSensor;
    public float MinRadiusSensor;
    public float Deployspeed;
    private bool Deploycollider;
    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
        PlayerMovement = GameObject.Find("PlayerComponents").GetComponent<PlayerCombatMovement>();
    }
    void Update()
    {
        Count = enemyInRange.Count;
        if (Input.GetKeyDown(KeyCode.R) && enemyInRange.Count != 0)
            Deploycollider = true;
        if (Input.GetKeyDown(KeyCode.Q))
            Deploycollider = false;
        if (Deploycollider)
        {
            if (myCollider.radius < RadiusSensor)
            {
                myCollider.radius += Deployspeed * Time.deltaTime;
            }
        }
        if (!Deploycollider)
        {
            if (myCollider.radius > MinRadiusSensor)
            {
                myCollider.radius -= Deployspeed * Time.deltaTime;
            }
        }
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            enemyInRange.Add(other.gameObject);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            enemyInRange.Remove(other.gameObject);
    }

    public void RemoveEnemies(GameObject EnemiesToRemove)
    {
        enemyInRange.Remove(EnemiesToRemove);
    }
}
