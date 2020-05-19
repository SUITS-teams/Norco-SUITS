using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnchor : MonoBehaviour {

    public GameObject worldUIRoot;

    void Update () {
        worldUIRoot.transform.position = GetComponent<OVRSkeleton> ().Bones[3].Transform.position;
    }

}