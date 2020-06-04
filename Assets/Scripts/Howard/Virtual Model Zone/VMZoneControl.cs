using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMZoneControl : MonoBehaviour
{

    //if the user leaves the zone, destorys virtual model object
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GameObject.Find("OVRCameraRig"))
        {
            Destroy(this.gameObject);
        }
    }
}
