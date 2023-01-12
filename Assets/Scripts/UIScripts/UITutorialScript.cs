using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITutorialScript : MonoBehaviour
{
    public Vector3 offSet;
    public GameObject spriteObject;
    private Vector3 OriginalPos;
    private SpriteRenderer sprite;
    private bool onTrigger;
    private GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = spriteObject.GetComponent<SpriteRenderer>();
        OriginalPos = sprite.gameObject.transform.position;
        sprite.gameObject.SetActive(false);

    }
    void LateUpdate()
    {
        if (onTrigger)
        {
            sprite.gameObject.SetActive(true);
            sprite.gameObject.transform.position = Player.transform.position + offSet;
        }
        else if (!onTrigger)
        {
            sprite.gameObject.SetActive(false);
            sprite.gameObject.transform.position = OriginalPos;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = true;
            Player = other.gameObject;
        }
    }
    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = false;
        }
    }
}
