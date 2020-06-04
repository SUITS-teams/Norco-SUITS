using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonUi : MonoBehaviour
{
    //telemetry Ui Icons ============================
    public Image oxygenIcon;                       //
    public Image waterIcon;                        //
    public Image fanIcon;                          //
    public Image powerIcon;                        //
    //telemetry Ui Sliders                         //
    public Image oxygenSlider;                     //
    public Image waterSlider;                      //
    public Image fanSlider;                        //
    public Image powerSlider;                      //
    //===============================================

    //warning Ui
    public WarningDisplay warningScript;
    public GameObject warningIcons;

    //Nav Ui
    public GameObject compass;

    //telemetry values (NOTE: will be change to private in the final project)
    public float oxygenValue;
    public float batteryValue;
    public float waterValue;
    public float fanValue;

    //private Vector3 iniRotation;

    void Awake()
    {
        //iniRotation = compass.transform.eulerAngles;
    }

    
    void Update()
    {
        //locks rotation of the compass (WIP: this can change to include calibrations)
        compass.transform.eulerAngles = new Vector3(0, 0, 0);

        //display fill telemetry fill bar
        powerSlider.GetComponent<Image>().fillAmount = batteryValue;
        oxygenSlider.GetComponent<Image>().fillAmount = oxygenValue;
        waterSlider.GetComponent<Image>().fillAmount = waterValue;
        fanSlider.GetComponent<Image>().fillAmount = fanValue;
        //check telemetry values to display approiate icon colors and bars
        checkValueCondition(oxygenIcon, oxygenValue);
        checkValueCondition(waterIcon, waterValue);
        checkValueCondition(fanIcon, fanValue);
        checkValueCondition(powerIcon, batteryValue);

        criticalWarningCheck();
    }



    //==== checkValueCondition() ===========================================
    /* Called with a telemetry icon image and value passed to check if the 
     * telemetry is low enough to change indicating colors. */
    //======================================================================
    private void checkValueCondition(Image icon, float teleValue)
    {
        if (teleValue  < 0.15f) { icon.color = Color.red; }
        else if (teleValue < 0.32f) { icon.color = Color.yellow; }
        else { icon.color = new Vector4(0f, 0.6f, 0f, 1f); }
    }



    //==== criticalWarningCheck() ==========================================
    /* Constantly gets called to check telemetry values, if those values are
     * critically low then display upper warning icons. */
    //======================================================================
    private void criticalWarningCheck()
    {
        //displays warning icons if one of the telemetry values is critically low
        warningIcons.SetActive(oxygenValue < 0.15f || waterValue < 0.15f || batteryValue < 0.15f || fanValue < 0.15f ? true : false);

        warningScript.displayIcon_Oxygen(oxygenValue < 0.15f ? true : false); //oxygen
        warningScript.displayIcon_Water(waterValue < 0.15f ? true : false); //water
        warningScript.displayIcon_Power(batteryValue < 0.15f ? true : false); //power
        warningScript.displayIcon_Fan(fanValue < 0.15f ? true : false); //fan
    }



    //Access Methods
    public float GetOxygenValue() { return oxygenValue; }
    public float GetBatteryValue() { return batteryValue; }
    public float GetWaterValue() { return waterValue; }
    public float GetFanValue() { return fanValue; }

}