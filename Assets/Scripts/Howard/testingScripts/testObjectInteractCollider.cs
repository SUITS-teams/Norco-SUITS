using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testObjectInteractCollider : MonoBehaviour
{
    public GameObject hand;

    
    void Awake()
    {
        this.transform.parent = hand.transform;
        this.transform.position = hand.GetComponent<OVRSkeleton>().Bones[0].Transform.position;
    }
}
