using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConstantDecreaseTeleValue : MonoBehaviour
{
    public FirstPersonUi suitData;
    public float decreaseRate;

    private float iniTime = 10;

    // Update is called once per frame
    void Update()
    {
        if (iniTime < 0)
        {
            suitData.oxygenValue = suitData.GetOxygenValue() > 0 ? suitData.GetOxygenValue() - decreaseRate : 0;
            suitData.batteryValue = suitData.GetBatteryValue() > 0 ? suitData.GetBatteryValue() - decreaseRate : 0;
            suitData.waterValue = suitData.GetWaterValue() > 0 ? suitData.GetWaterValue() - decreaseRate : 0;
            suitData.fanValue = suitData.GetFanValue() > 0 ? suitData.GetFanValue() - decreaseRate : 0;
        }
        else
        {
            iniTime--;
        }
    }
}
