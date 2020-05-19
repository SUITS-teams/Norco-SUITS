using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: please apply this script to right hand prefab to test
public class UIAnchor_withVector2 : MonoBehaviour
{
    public GameObject worldUIRoot;
    private Transform pinkyBonePosition;
    private Transform palmBonePosition;

    void Start()
    {
        pinkyBonePosition = GetComponent<OVRSkeleton>().Bones[16].Transform;
        //wristBonePosition = GetComponent<OVRSkeleton> ().Bones[1].Transform;
        //palmBonePosition = GetComponent<OVRSkeleton> ().Bones[0].Transform;
        palmBonePosition = GetComponent<OVRSkeleton>().Bones[0].Transform;

    }

    void Update()
    {
        worldUIRoot.transform.position = GetComponent<OVRSkeleton>().Bones[3].Transform.position;

        float angleXY = Vector2.Angle(Vector2.left, transform.up);
        float angleXZ = Vector3.Angle(new Vector3(0, 10000f, 0), transform.up);
        if (angleXY <= 90f && angleXZ <= 30)
        {
            worldUIRoot.SetActive(false);
        }
        else
        {
            worldUIRoot.SetActive(true);
        }
    }
}
