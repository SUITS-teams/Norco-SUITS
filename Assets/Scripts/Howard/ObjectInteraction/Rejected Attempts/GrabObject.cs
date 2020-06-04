using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrabObject : MonoBehaviour
{
    public GameObject itemSlot;

    //struct design
    private struct hand
    {
        public Transform[] fingerBones;
        public bool[] isGrip;
        public GameObject itemInHand;
    }

    const int SIZE = 5;
    private hand Userhand; //struct declaration
    private int index = 0;
    private RaycastHit hit;
    private LineRenderer rayRenderer;

    //finger tip bones
    //private Transform[] fingerBones = new Transform[SIZE];
    //private Transform thumbFinger;
    //private Transform firstFinger;
    //private Transform secondFinger;
    //private Transform thirdFinger;
    //private Transform fourthFinger;

    void Awake()
    {
        itemSlot.transform.parent = GetComponent<OVRSkeleton>().Bones[0].Transform;
        itemSlot.transform.position = GetComponent<OVRSkeleton>().Bones[0].Transform.position;
        itemSlot.transform.position += new Vector3(0f, -0.4f, 0.5f);
    }
    
    void Start()
    {
        rayRenderer = GetComponent<LineRenderer>();

        Userhand.fingerBones = new Transform[SIZE];
        Userhand.isGrip = new bool[SIZE];
    
        Userhand.fingerBones[0] = GetComponent<OVRSkeleton>().Bones[5].Transform; //Thumb
        Userhand.fingerBones[1] = GetComponent<OVRSkeleton>().Bones[8].Transform; //first
        Userhand.fingerBones[2] = GetComponent<OVRSkeleton>().Bones[11].Transform; //second
        Userhand.fingerBones[3] = GetComponent<OVRSkeleton>().Bones[14].Transform; //third
        Userhand.fingerBones[4] = GetComponent<OVRSkeleton>().Bones[18].Transform; //fourth

        for (int i = 0; i < SIZE; ++i) { Userhand.isGrip[i] = false; }
    }

    //Update() loops through each finger bone per
    void Update()
    {
        Vector3 rayEndPoint = new Vector3(Userhand.fingerBones[index].position.x, Userhand.fingerBones[index].position.y - 2f, Userhand.fingerBones[index].position.z);

        {//===== Line Renderer ========== Debug ================
            rayRenderer.positionCount = 2;
            Vector3[] vector3Array = new Vector3[2];
            vector3Array[0] = Userhand.fingerBones[0].position;
            vector3Array[1] = rayEndPoint;
            rayRenderer.SetPositions(vector3Array);
        }//====================================================

        if (Physics.Raycast(new Ray(Userhand.fingerBones[index].position, rayEndPoint), out hit, 1.5f))
        {
            Userhand.isGrip[index] = hit.collider.tag == "interactable" ? true : false;
        }

        if (checkFingerRays())
        {
            Userhand.itemInHand = hit.collider.gameObject;
            Userhand.itemInHand.GetComponent<Rigidbody>().isKinematic = true;
        }
        else {
            Userhand.itemInHand.GetComponent<Rigidbody>().isKinematic = false;
            Userhand.itemInHand = null;
        }

        index += index < SIZE - 1 ? 1 : 0;
    }



    private bool checkFingerRays()
    {
        for (int i = 0; i < SIZE; ++i)
        {
            if (!Userhand.isGrip[i]) { return false; }
        }

        return true;
    }
}
