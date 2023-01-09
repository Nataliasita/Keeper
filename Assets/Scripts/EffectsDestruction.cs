using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsDestruction : MonoBehaviour
{
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", lifeTime);
    }

    // Update is called once per frame
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
