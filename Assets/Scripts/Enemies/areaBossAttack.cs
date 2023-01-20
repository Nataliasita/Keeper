using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaBossAttack : MonoBehaviour
{
    public float scaleRatio;
    public Vector3 actualScale;
    public Vector3 scaleRatioVector;
    public float ScaleSpeed;
    public float MaxScale;
    public float Damage;
    public float MaxLifeTime;

    private void Start()
    {
        actualScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        scaleRatioVector = new Vector3(scaleRatio, scaleRatio, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (actualScale.x >= MaxScale && actualScale.y >= MaxScale)
        {
            actualScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            Invoke("LifeTimeKill", MaxLifeTime);
        }
        else
        {
            this.transform.localScale = actualScale + scaleRatioVector * Time.deltaTime * ScaleSpeed;
            actualScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    void LifeTimeKill()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(Damage, true);
        }
    }

}
