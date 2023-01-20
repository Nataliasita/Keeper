using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardStats : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public int punchCuantity;
     public int MaxCuantity;
    public GameObject prefabReward;
    public void TakeDamage(float damage)
    {
        RewardExplotion(punchCuantity);
        health -= damage;
        if (health <= 0)
        {
            RewardExplotion(MaxCuantity);
            Destroy(this.gameObject);
        }
    }
    public void RewardExplotion(int items)
    {
        for (int i = 0; i < items; i++)
        {
            Vector3 posInicial = new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(0f, 2f), transform.position.z + Random.Range(-2f, 2f));
            Instantiate(prefabReward, posInicial, Quaternion.identity);
            prefabReward.GetComponent<Rigidbody>().AddForce(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f, 4f), ForceMode.Impulse);
        }
    }
}
