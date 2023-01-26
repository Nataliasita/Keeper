using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class History : MonoBehaviour
{
    string textValue = "Inside the tropical forest, a sacred object with the ability to amplify powers is hidden. A shaman from a forgotten tribe, full of evil, seeks to seize all the natural resources that are protected by their ancestors. Your guardian mission is to recover this powerful gem to defeat evil. For this, it will have several collectibles that will give you new abilities, among them a macuahuitl that will allow you to cancel the possession of animals without causing any damage and thus decrease the power of the shaman, in each of the levels you will be able to find the pieces of the sacred totem that It will increase your magical powers, muster them bravely to reach the final battle in the temple";
    public TextMeshProUGUI titletext;
    // Start is called before the first frame update


    void Start()
    {
        StartCoroutine(ContentText());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ContentText()
     {
         foreach(char caracter in textValue)
         {
             titletext.text = titletext.text + caracter;
             yield return new WaitForSeconds(0.05f);

        }


    } 


}
