using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrackGrabbing : MonoBehaviour
{

    public Transform itemTracker;

    const int SIZE = 4;
    private Transform[] fingerBones;
    private Transform ThumbBone;
    private GameObject closeObject = null;
    private bool isGrabed;
    public GameObject[] allObjects;

    // Start is called before the first frame update
    void Start()
    {
        fingerBones = new Transform[SIZE];

        fingerBones[0] = GetComponent<OVRSkeleton>().Bones[8].Transform; //first
        fingerBones[1] = GetComponent<OVRSkeleton>().Bones[11].Transform; //second
        fingerBones[2] = GetComponent<OVRSkeleton>().Bones[14].Transform; //third
        fingerBones[3] = GetComponent<OVRSkeleton>().Bones[18].Transform; //fourth

        ThumbBone = GetComponent<OVRSkeleton>().Bones[5].Transform; //thumb

        itemTracker.parent = GetComponent<OVRSkeleton>().Bones[0].Transform;
        itemTracker.localPosition = new Vector3(0f, -0.6f, 0.6f);
        allObjects = UnityEngine.Object.FindObjectsOfType<GameObject> ();
        StartCoroutine (PickupCheck ());
    }

    // Update is called once per frame
    void Update()
    {
        //checks the distance between top four finger bones and the thumb
        if (isPinching())
        {
            isGrabed = true;
            closeObject.GetComponent<Rigidbody>().isKinematic = false;
            closeObject.transform.position = itemTracker.position;
        }
        else
        {
            isGrabed = false;
            closeObject.GetComponent<Rigidbody>().isKinematic = true;
            closeObject = null;
        }

        
    }


    //===== isPinching() =============================================
    /* checks if a finger is in pinching distance with the thumb. Returns a bool */
    //================================================================
    private bool isPinching()
    {
        foreach (Transform x in fingerBones) {
            if (Vector3.Distance(ThumbBone.position, x.position) < 0.21f) { return true; }
        }

        return false;
    }
    //================================================================

    IEnumerator PickupCheck () {
        float closestDistance = 10000f;
        float distance = 0;
        yield return new WaitForSeconds (0.25f);
        foreach (GameObject go in allObjects) {
            if (Vector3.Distance (go.transform.position, fingerBones[0].position) < closestDistance) {
                closeObject = go;
            }
        }
        closestDistance = 10000f;
        StartCoroutine (PickupCheck ());
    }

}
