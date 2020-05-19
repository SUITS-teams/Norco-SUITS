using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class VRPlayerEnable : MonoBehaviourPun {

    void Update () {
        if (photonView.IsMine && PhotonNetwork.IsConnected) {
            //I am the player
            transform.GetChild (0).gameObject.SetActive (true);
            gameObject.GetComponent<OVRCameraRig> ().enabled = true;
            gameObject.GetComponent<OVRManager> ().enabled = true;
            gameObject.GetComponent<OVRHeadsetEmulator> ().enabled = true;
        }
    }

}