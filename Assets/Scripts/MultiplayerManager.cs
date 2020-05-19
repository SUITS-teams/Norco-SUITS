using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MultiplayerManager : MonoBehaviour {

    public GameObject VRAstronaut;
    public List<GameObject> photonObjects = new List<GameObject> ();

    void Start () {
        if (GameObject.FindGameObjectsWithTag ("astronaut").Length > 0) {
            GameObject pad = PhotonNetwork.Instantiate (this.VRAstronaut.name, new Vector3 (-3.5f, 1.8f, -1.2f), Quaternion.identity, 0);
            //pad.transform.eulerAngles = new Vector3 (0f, 180f, 0f);
        } else {
            GameObject pad = PhotonNetwork.Instantiate (this.VRAstronaut.name, new Vector3 (3.5f, 1.8f, 4f), Quaternion.identity, 0);
            //pad.transform.eulerAngles = new Vector3 (0f, 180f, 0f);
        }
        
        if (GameObject.FindGameObjectsWithTag ("rock").Length != null) {
            foreach (GameObject go in photonObjects) {
                PhotonNetwork.Instantiate (go.name, new Vector3 (6.8f, 0f, -11.5f), Quaternion.identity, 0);
            }
        }
    }

}