using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class countSpecialShotUI : MonoBehaviour
{
    public bool SpecialShot1;
    public float ShotCount;
    [SerializeField] TextMeshProUGUI shotCountNumberText;
    public StatsManager statsManager;
    // Start is called before the first frame update
    void Start()
    {
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        shotCountNumberText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpecialShot1)
        {
            ShotCount = statsManager.especialShot1;
            shotCountNumberText.text = " x" + ShotCount.ToString("0");
        }
        if (!SpecialShot1)
        {
            ShotCount = statsManager.especialShot2;
            shotCountNumberText.text = " x" + ShotCount.ToString("0");
        }
    }
}
