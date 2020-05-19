using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUpTest : MonoBehaviour {

    public GameObject rightHandPanel;

    void OnTriggerEnter (Collider other) {
        rightHandPanel.SetActive (true);
    }

    void OnTriggerExit () {
        rightHandPanel.SetActive (false);
    }

}
