using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIAnchor_howard : MonoBehaviour {
    //UI attachments
    public GameObject UiRoot;
    public GameObject panel1;
    //public GameObject handUpChecker;
    //public GameObject telePanel;
    public GameObject wristSlot;
    public GameObject palmSlot;
    public GameObject cameraRoot;

    //Bones
    private Transform pinkyBonePosition;
    private Transform wristBonePosition;
    private Transform palmBonePosition;
    private Transform indexBonePosition;

    //===== Queue method ================   CONFIRMED WORKS (kind of)
    private Transform frontChild;
    //===================================

    //angle
    float x_angle;
    float y_angle;

    void Start() {
        pinkyBonePosition = GetComponent<OVRSkeleton> ().Bones[16].Transform;
        wristBonePosition = GetComponent<OVRSkeleton> ().Bones[1].Transform;
        palmBonePosition = GetComponent<OVRSkeleton> ().Bones[0].Transform;
        indexBonePosition = GetComponent<OVRSkeleton>().Bones[20].Transform;

        //==== making the UI element for palmSlot as a child of palm bone. Comment out and uncomment palmSlot.transform.position for position method =============================
        palmSlot.transform.parent = palmBonePosition;
        palmSlot.transform.position = new Vector3(palmBonePosition.position.x, palmBonePosition.position.y - 0.06f, palmBonePosition.position.z);
        //========================================================================================================================================================================
    }

    void Update() {
        if (panel1.transform.parent != null) { panel1.transform.position = new Vector3(pinkyBonePosition.position.x - 0.17f, pinkyBonePosition.position.y, pinkyBonePosition.position.z); }
        wristSlot.transform.position = new Vector3(wristBonePosition.position.x + 0.1f, wristBonePosition.position.y + 0.07f, wristBonePosition.position.z);
        //handUpChecker.transform.position = wristBonePosition.position;
        //handUpChecker.transform.rotation = wristBonePosition.rotation;
        //if (telePanel.transform.parent != null) {
        //    telePanel.transform.position = new Vector3(indexBonePosition.position.x, indexBonePosition.position.y + 0.07f, indexBonePosition.position.z - 0.02f);
        //    telePanel.transform.LookAt(GetComponent<Camera>().transform.position, Vector3.up);
        //}


        //uncomment for position method use
        //palmSlot.transform.position = new Vector3(palmBonePosition.position.x, palmBonePosition.position.y, palmBonePosition.position.z);

        x_angle = indexBonePosition.rotation.x;
        y_angle = indexBonePosition.rotation.y;

        //===== Queue method ======================================================
        frontChild = UiRoot.transform.GetChild(0); //sets transform of first child to transform variable
        frontChild.SetAsLastSibling(); //moves first child to the last index slot
        frontChild.gameObject.SetActive(x_angle >= 0.55f && y_angle <= -0.1); //setting the UI element active/unactive
        //=========================================================================


        //===== Old method ========================================================
        /* uncomment to use
        Vector3 targetDir = new Vector3 (cameraRoot.transform.position.x, cameraRoot.transform.position.y, cameraRoot.transform.position.z + 10000f) - cameraRoot.transform.position;
        float angle = Vector3.Angle (targetDir, -palmBonePosition.up);
        if (angle <= 30f) {
            UiRoot.SetActive(true);
        } else {
            UiRoot.SetActive(false);
        }
        */
        //=========================================================================
    }

}