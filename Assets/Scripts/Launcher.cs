using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks {

    public string gameVersion = "1";
    void Awake () {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start () {
        Connect ();
    }

    public void Connect () {
        if (PhotonNetwork.IsConnected) {
            PhotonNetwork.JoinRandomRoom ();
        } else {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings ();
        }
    }

    public override void OnConnectedToMaster () {
        Debug.Log ("Connected to Master");
        PhotonNetwork.JoinRandomRoom ();
    }


    public override void OnDisconnected (DisconnectCause cause) {
        Debug.LogWarningFormat ("Disconnected with reason: ", cause);
    }

    public override void OnJoinRandomFailed (short returnCode, string message) {
        Debug.Log ("No open room, making one");
        PhotonNetwork.CreateRoom (null, new RoomOptions ());
    }

    public override void OnJoinedRoom () {
        Debug.Log ("Joined room");
        PhotonNetwork.LoadLevel ("GeologySite_Test");
    }
}