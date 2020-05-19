using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PUNPlayer : MonoBehaviour {

    void Start () {
        if (PhotonNetwork.IsMasterClient == true) {
            //Enable components
            transform.GetChild (0).GetComponent<OVRCameraRig> ().enabled = true;
            transform.GetChild (0).GetComponent<OVRManager> ().enabled = true;
            transform.GetChild (0).transform.GetChild (0).transform.GetChild (4).transform.GetChild (1).gameObject.SetActive (true);
            transform.GetChild (0).transform.GetChild (0).transform.GetChild (5).transform.GetChild (1).gameObject.SetActive (true);
        }
    }

}