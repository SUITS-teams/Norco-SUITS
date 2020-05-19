using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBehavior : MonoBehaviour
{
    public Transform User;

    private bool isLocked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        User = GameObject.Find("OVRCameraRig").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocked)
        {
            this.transform.LookAt(User);
            this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y + 180, 0);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        isLocked = !isLocked;
    }

}
