using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDebugRotation : MonoBehaviour
{
    public GameObject cameraRoot;
    public GameObject debugDisplay;
    public GameObject handTracker;

    //bone class reference
    public OVRSkeleton boneRoot;

    private Transform bone;

    // Start is called before the first frame update
    void Start()
    {
        debugDisplay.transform.parent = cameraRoot.transform;
        bone = boneRoot.Bones[1].Transform;

        handTracker.transform.parent = bone;
    }

    // Update is called once per frame
    void Update()
    {
        debugDisplay.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Rotation Vector\nX: " + handTracker.transform.rotation.x.ToString() + " Y: " + handTracker.transform.rotation.y.ToString() + " Z: " + handTracker.transform.rotation.z.ToString();
    }
}
