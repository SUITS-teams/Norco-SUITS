using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class HandTrackOVRGrabber : OVRGrabber
{
    public float pinchThreshold = 0.7f;

    private OVRHand hand;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        hand = GetComponent<OVRHand>();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        
        bool isPinched = checkIsPinching();
        if (!m_grabbedObj && isPinched && m_grabCandidates.Count > 0) { GrabBegin(); }
        else if (m_grabbedObj && !isPinched) { GrabEnd(); }
    }


    //===== CheckPinchStrength() ==================================================
    /* Returns a boolean at least one of the 4 top fingers are pinching. Loops
     * through each finger with a switch in a for-loop for each HandFinger emun. */
    //=============================================================================
    private bool checkIsPinching()
    {
        float pinchStrength = 0;

        for (int i = 1; i < 4; ++i)
        {
            switch (i)
            {
                case 0:
                    pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
                    break;
                case 1:
                    pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle);
                    break;
                case 2:
                    pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);
                    break;
                case 3:
                    pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Pinky);
                    break;
            }

            if (pinchStrength > pinchThreshold) { return true; }
        }

        return false;
    }
    //=============================================================================



    //===== GrabEnd() ===== OVERRIDE ==============================================
    /* Overrided to apply physics for released Objects if gravity is used on rigidbody.
     * Makes throwing objects possible with hand-tracking. */
    //=============================================================================
    protected override void GrabEnd()
    {
        //checks the Obj's rigidbody for using gravity if physics is applied to the grabbed Obj
        if (m_grabbedObj && m_grabbedObj.GetComponent<Rigidbody>().useGravity)
        {
            GrabbableRelease(
                (transform.position - m_lastPos) / Time.fixedDeltaTime,                 //linear velocity
                (transform.eulerAngles - m_lastRot.eulerAngles) / Time.fixedDeltaTime   //angular velocity
            );
        }

        GrabVolumeEnable(true);
    }
    //=============================================================================
}