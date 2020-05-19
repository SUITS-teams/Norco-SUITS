using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningDisplay : MonoBehaviour
{
    public GameObject oxygenWarning;
    public GameObject waterWarning;
    public GameObject powerWarning;
    public GameObject fanWarning;
    public float fadeSpeed = 0.002f;

    //fade in and out control variables
    private float opacity = 1f;
    private bool isMaxed = true;

    // Start is called before the first frame update
    void Awake()
    {
        oxygenWarning.SetActive(false);
        waterWarning.SetActive(false);
        powerWarning.SetActive(false);
        fanWarning.SetActive(false);
    }

    //==== Update() is used for fade in and out effect =========================
    void Update()
    {
        Color lerpedAlpha = new Vector4(255f, 0f, 0f, opacity);

        //oxygenIcon fade in effect
        if (oxygenWarning.active) { oxygenWarning.GetComponent<Image>().color = lerpedAlpha; }
        //waterIcon fade in effect
        if (waterWarning.active) { waterWarning.GetComponent<Image>().color = lerpedAlpha; }
        //powerIcon fade in effect
        if (powerWarning.active) { powerWarning.GetComponent<Image>().color = lerpedAlpha; }
        //fanIcon fade in effect
        if (fanWarning.active) { fanWarning.GetComponent<Image>().color = lerpedAlpha; }

        //opacity control
        opacity += (isMaxed ? -fadeSpeed : fadeSpeed);
        if (opacity <= 0.2f && isMaxed) { isMaxed = false; }
        else if (opacity > 0.99f && !isMaxed) { isMaxed = true; }
    }
    //===========================================================================


    //all in one function with string parameter
    public void displayIcon(string input, bool isActive)
    {
        if (input.ToLower() == "oxygen") { displayIcon_Oxygen(isActive); }
        else if (input.ToLower() == "water") { displayIcon_Water(isActive); }
        else if (input.ToLower() == "power") { displayIcon_Power(isActive); }
        else if (input.ToLower() == "fan") { displayIcon_Fan(isActive); }
    }

    //individual icon functions
    public void displayIcon_Oxygen(bool isActive) { oxygenWarning.SetActive(isActive); } //oxygen
    public void displayIcon_Water(bool isActive) { waterWarning.SetActive(isActive); } //water
    public void displayIcon_Power(bool isActive) { powerWarning.SetActive(isActive); } //power
    public void displayIcon_Fan(bool isActive) { fanWarning.SetActive(isActive); } //fan
}
