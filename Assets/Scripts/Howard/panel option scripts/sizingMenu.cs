using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizingMenu : MonoBehaviour
{
    //boolean to toggle between press to max/min panel or two finger sizing; when applying script.
    public bool staticSizing = false;
    public GameObject objToSize;
    public float minimumScale = 1f;
    public float maximumScale = 1.7f;

    //gameObject variables to store two first object entering the collider. Will be the two fingers to size UI.
    private GameObject obj1;
    private GameObject obj2;

    private float iniPosition;
    private float newPosition;
    

    // Update is called once per frame
    void Update()
    {
        if (!staticSizing)
        {
            twoFingerSizing();
        }
    }



    private void twoFingerSizing()
    {
        if (obj1 != null && obj2 != null)
        {
            newPosition = Vector3.Distance(obj1.transform.position, obj2.transform.position);

            if (newPosition > iniPosition)
            {
                objToSize.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                iniPosition = newPosition;
            }
            else if (newPosition < iniPosition)
            {
                objToSize.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                iniPosition = newPosition;
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (staticSizing)
        {
            objToSize.transform.localScale = (objToSize.transform.localScale.x == minimumScale ? new Vector3(maximumScale, maximumScale, maximumScale) : new Vector3(minimumScale, minimumScale, minimumScale));
        }
        else
        {
            if (obj1 == null) { obj1 = other.gameObject; }
            else if (obj2 == null) { obj2 = other.gameObject; }

            if (obj1 != null && obj2 != null)
            {
                iniPosition = Vector3.Distance(obj1.transform.position, obj2.transform.position);
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (!staticSizing)
        {
            obj1 = (other.gameObject == obj1 ? null : obj1);
            obj2 = (other.gameObject == obj2 ? null : obj2);
            iniPosition = (obj1 == null || obj2 == null ? 0 : iniPosition);
        }
    }
}
