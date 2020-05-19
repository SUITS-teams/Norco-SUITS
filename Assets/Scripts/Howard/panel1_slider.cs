using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel1_slider : MonoBehaviour
{ 
    public GameObject slider;
    public GameObject sideMenu;

    private bool isTouching = false;
    private GameObject objInZone;
    private float position;
    private float iniPosition;
    
    void Start()
    { 
        sideMenu.SetActive(false);
        objInZone = null;
    }



    void Update()
    {
        if (isTouching) // tracks how far the left or right the finger in on the pad is
        {
            slider.transform.position = new Vector3(objInZone.transform.position.x, 0, 0);
            position = slider.gameObject.transform.localPosition.x;
            
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (objInZone == null) //locks the first object to touch the pad. Stops other gameObjects(other bones) from interfering
        {
            objInZone = other.gameObject;
            slider.transform.position = new Vector3(objInZone.transform.position.x, 0, 0);
            iniPosition = slider.transform.localPosition.x;
            isTouching = true;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objInZone) //checks if the obj leaving is the finger on the slider
        {
            float distance = position - iniPosition;

            //checks if the magnetude of distance greater-or-equal than 1
            if ((distance < 0 ? -distance : distance) >= 1f) 
            {
                //checks if distance is positive display menu, if negative hide
                sideMenu.SetActive(distance > 0f);
            }
            //if (position > 0) { sideMenu.SetActive(true); }
            //else if (position < 0) { sideMenu.SetActive(false); }
            objInZone = null;
            isTouching = false;
        }
    }
}
