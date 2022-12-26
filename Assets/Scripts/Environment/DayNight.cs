using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    private float min;

    public float grade;

    public float timeSpeed = 1;

    public Light lune;

    public Light auxLune;

   public NewCycle skySceneChange;

    void Update()
    {
        min += timeSpeed *  Time.deltaTime;

        if(min >= 1440)
        {
            min=0;
        }
        grade = min / 4 ;
        this.transform.localEulerAngles = new Vector3(grade , -90f , 0f);

        skySceneChange.ChangeSkyBox(grade);  
        if(grade >= 180)
        {
            this.GetComponent<Light>().enabled=false;
            lune.enabled=true;
            auxLune.enabled=true;
        }else{
            this.GetComponent<Light>().enabled=true;
            lune.enabled=false;
            auxLune.enabled=false;
        }
    }
}
