using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContextualUIContentd : MonoBehaviour
{
    public static int index;
    public bool CanNavigate;

    [TextArea]
    public string[] contendTittles;
    public string[] contendText;
    public Sprite[] contendImages;
    private TextMeshProUGUI titletext;
    private TextMeshProUGUI Contendtext;
    private Image ContendImage;


    // Start is called before the first frame update
    void Start()
    {
        titletext = this.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        Contendtext = this.gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        ContendImage = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanNavigate)
        {
            this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (CanNavigate)
        {
            this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
        }
        ContendImage.sprite = contendImages[index];
        titletext.text = contendTittles[index];
        Contendtext.text = contendTittles[index];

    }
    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        CanNavigate = false;
    }
    public void OpenPanel()
    {
        this.gameObject.SetActive(true);
        CanNavigate = true;
        Time.timeScale = 0f;
    }
    public void nextPanel()
    {
        if (CanNavigate && index < contendTittles.Length - 1)
        {
            index++;
        }
    }
    public void PreviousPanel()
    {
        if (CanNavigate && index > 0)
        {
            index--;
        }
    }

}
