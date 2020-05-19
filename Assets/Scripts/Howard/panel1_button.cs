using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel1_button : MonoBehaviour
{
    public bool isAnchored = true;

    //private string boneTag;

    void Start()
    {
        //WIP
        //GameObject.Find("LeftHandAnchor").GetComponentInChildren<OVRSkeleton>().Bones[20].gameObject.tag == "finger";
        //boneTag = GameObject.Find("LeftHandAnchor").GetComponentInChildren<OVRSkeleton>().Bones[23].;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == boneTag)
        //{
            if (isAnchored)
            {
                isAnchored = false;
                this.transform.parent = null;
                //this.transform.position += new Vector3(0, 2.5f, 0);
            }
            else
            {
                isAnchored = true;
                this.transform.parent = GameObject.Find("UI Right Hand").transform;
            }
        //}
    }
    
}