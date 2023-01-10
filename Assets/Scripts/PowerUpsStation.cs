using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsStation : MonoBehaviour
{
    public GameObject canvasUI;
    public GameObject PowerUPcanvas;
    public bool playerInRange;
    public float RangeDetection;
    public LayerMask whatIsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        canvasUI = GameObject.Find("CanvasUIElements");
        PowerUPcanvas = GameObject.Find("ManagerStats");
        PowerUPcanvas.SetActive(false);

    }
    private void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position, RangeDetection, whatIsPlayer);
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            canvasUI.SetActive(false);
            PowerUPcanvas.SetActive(true);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RangeDetection);
    }
}
