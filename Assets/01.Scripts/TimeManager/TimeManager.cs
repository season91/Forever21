using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update

    float TotalTime = 0f;

    //float DeltaTime = 1f;

    bool CalculateTime = false;

    public void TimeSet(bool _TimeSet)
    {
        if(_TimeSet == true)
        {
            CalculateTime = true;
        }
        else
        {
            CalculateTime = false;
            TotalTime = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CalculateTime)
        {
            TimeUpdate();
        }
    }

    void TimeUpdate()
    {
        TotalTime += Time.deltaTime;
    }
}
