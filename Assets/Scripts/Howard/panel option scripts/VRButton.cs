using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: This is a very messy simple button script but works
//Refactoring HIGHLY recommended

public class VRButton : MonoBehaviour
{
    //enum for what panel this button spawns
    public enum Panel //can add more
    {
        settings,
        telemetry,
    }

    //enum for the axis that the button moves along
    public enum AxisType
    {
        X_Axis,
        Y_Axis,
        Z_Axis
    }

    public Collider buttonTrigger; //REQUIRED FIELD
    public ExternalUiManager externalUi; //REQUIRED FIELD
    public Panel spawningPanel;
    public AxisType axisMovedOn;
    public float returnRate = 0.25f;

    private Vector3 neutralPosition;
    private Vector3 thresholdPosition;
    private Vector3 lockedAngle;
    private Vector3 vectorRate;

    
    void Awake()
    {
        neutralPosition = this.transform.localPosition;
        lockedAngle = this.transform.localEulerAngles;

        switch (axisMovedOn)
        {
            case AxisType.X_Axis:
                vectorRate = new Vector3(-returnRate, 0f, 0f);
                break;

            case AxisType.Y_Axis:
                vectorRate = new Vector3(0f, -returnRate, 0f);
                break;

            case AxisType.Z_Axis:
                vectorRate = new Vector3(0f, 0f, -returnRate);
                break;
        }
        thresholdPosition = buttonTrigger.transform.localPosition;

        Debug.Log("neutral X: " + neutralPosition.x);
        Debug.Log("neutral Y: " + neutralPosition.y);
        Debug.Log("neutral Z: " + neutralPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        //each case will check the change in original localPosition and toggle a bool for isMoving.
        //if the button is pulled out, then the button will teleport back to neutralPosition.
        switch (axisMovedOn)
        {
            case AxisType.X_Axis:
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, neutralPosition.y, neutralPosition.z);
                this.GetComponent<Rigidbody>().velocity = this.transform.localPosition.x > neutralPosition.x ? vectorRate : Vector3.zero;
                if (this.transform.localPosition.x < neutralPosition.x) { this.transform.localPosition = neutralPosition; }
                break;

            case AxisType.Y_Axis:
                this.transform.localPosition = new Vector3(neutralPosition.y, this.transform.localPosition.y, neutralPosition.z);
                this.GetComponent<Rigidbody>().velocity = this.transform.localPosition.y > neutralPosition.y ? vectorRate : Vector3.zero;
                if (this.transform.localPosition.y < neutralPosition.y) { this.transform.localPosition = neutralPosition; }
                break;

            case AxisType.Z_Axis:
                this.transform.localPosition = new Vector3(neutralPosition.x, neutralPosition.y, this.transform.localPosition.z);
                this.GetComponent<Rigidbody>().velocity = this.transform.localPosition.z > neutralPosition.z ? vectorRate : Vector3.zero;
                if (this.transform.localPosition.z < neutralPosition.z) { this.transform.localPosition = neutralPosition; }
                break;
        }
        //this.transform.localEulerAngles = lockedAngle; //locks local rotation

        //gives velocity to the button in order to spring back from a press
        //this.GetComponent<Rigidbody>().velocity = isMoving ? vectorRate : new Vector3(0, 0, 0);
    }

    


    void OnTriggerStay(Collider other)
    {
        if (other.GetInstanceID() == buttonTrigger.GetInstanceID()) 
        {
            switch (axisMovedOn)
            {
                case AxisType.X_Axis:
                    if (this.transform.localPosition.x > thresholdPosition.x) { this.transform.localPosition = thresholdPosition; }
                    break;

                case AxisType.Y_Axis:
                    if (this.transform.localPosition.y > thresholdPosition.y) { this.transform.localPosition = thresholdPosition; }
                    break;

                case AxisType.Z_Axis:
                    if (this.transform.localPosition.z > thresholdPosition.z) { this.transform.localPosition = thresholdPosition; }
                    break;
            }
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.GetInstanceID() == buttonTrigger.GetInstanceID())
        {
            switch (spawningPanel)
            {
                case Panel.settings:
                    externalUi.SpawnSetting();
                    break;
                case Panel.telemetry:
                    externalUi.SpawnTelemetry();
                    break;
                default:
                    Debug.Log("No Panel has been selected");
                    break;
            }
        }
    }
}
