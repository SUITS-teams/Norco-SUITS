using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBehavior : MonoBehaviour
{
    public Transform User;
    public bool isButtonToggle;
    public Transform panelTransform;

    private bool isLocked = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        User = GameObject.Find("OVRCameraRig").transform;
        if (panelTransform == null) { panelTransform = this.panelTransform; }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocked)
        {
            panelTransform.transform.LookAt(User);
            panelTransform.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y + 180f, 0);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        isLocked = !isLocked;
    }

}
