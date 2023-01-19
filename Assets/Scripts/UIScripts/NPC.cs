using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ContinueButton;
    public TextMeshProUGUI dialoguetext;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool PlayerIsClose;
    public float sightRange;
    public LayerMask whatIsPlayer;
    void Update()
    {
        PlayerIsClose = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (!PlayerIsClose) ZeroText();
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsClose)
        {
            if (Panel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                Panel.SetActive(true);
                StartCoroutine(typing());
            }
        }
        if (dialoguetext.text == dialogue[index])
        {
            ContinueButton.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && PlayerIsClose)nextLine();
    }
    IEnumerator typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialoguetext.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void ZeroText()
    {
        dialoguetext.text = "";
        index = 0;
        Panel.SetActive(false);
    }
    public void nextLine()
    {
        ContinueButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialoguetext.text = "";
            StartCoroutine(typing());
        }
        else
        {
            ZeroText();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<CombatSystem>().comboIndex = 0;
            other.GetComponent<PlayerCombatMovement>().CanJump = false;
        }
    }
     private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerCombatMovement>().CanJump = true;
        }
    }
}
