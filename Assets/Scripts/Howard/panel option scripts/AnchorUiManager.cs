using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorUiManager : MonoBehaviour
{
    public Transform ObjAnchoredTo; //internal UI gameObject
    public GameObject panel;

    private bool isAnchored = true;

    private void OnTriggerEnter(Collider other) //on button press
    {
        AnchorUi();
    }


    public void AnchorUi()
    {
        if (isAnchored) //checks if UI is anchored
        {
            //unanchors UI to external UI
            panel.transform.parent = null;
            panel.transform.position += new Vector3(0, 0, 0.05f);
        }
        else
        {
            //anchors UI to internal UI
            panel.transform.parent = ObjAnchoredTo;
        }

        isAnchored = !isAnchored; //flip boolean
    }
}
