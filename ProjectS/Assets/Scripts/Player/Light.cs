using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Light light;
    void Update()
    {
        if (GameManager.Instance.DayNightManager.currentTime == TimeOfDay.Night){
            light.enabled = true;
        }
        else{
            light.enabled = false;
        }
    }
}
