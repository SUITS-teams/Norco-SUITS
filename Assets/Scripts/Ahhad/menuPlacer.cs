using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//call the speech commands script and see if "settings" was said using a boolean var
//if true, this script will open the external menu (currently a placeholder object)
//1 unity unit away from the face and follow wherever you're looking until you lock it in place
public class menuPlacer : MonoBehaviour
{

    public GameObject menuPlaceholder;
    //public AzureSpeechCommands jarvisReference;//using to reference the settingsPanel object 
    public bool isStationary = false;//bool to see if the spawned menu has been anchored in place or still following camera
    
    // Start is called before the first frame update
    void Start()
    {
        //jarvisReference = GetComponent<AzureSpeechCommands>();
        //Instantiate(jarvisReference.settingsPanel);
    }

    // Update is called once per frame
    void Update()
    {
        //if "settings" is said and the panel is activated, the spawn location will be 1 unity unit away
        // GetComponent(MeshRenderer).enabled(false);
        //GameObject.Find("menuPlaceholder").transform.localScale = new Vector3(0, 0, 0);
       
            //jarvisReference.settingsPanel.SetActive(true);
            menuPlaceholder.SetActive(true);
        //GameObject.Find("menuPlaceholder").transform.localScale = new Vector3(1, 1, 1);
       
        Vector3 fillerPos = Camera.main.ViewportToWorldPoint(transform.position);
        fillerPos.x = Mathf.Clamp01(fillerPos.x);
        fillerPos.y = Mathf.Clamp01(fillerPos.y);
        fillerPos.z = Mathf.Clamp01(fillerPos.z);
        transform.position = Camera.main.ViewportToWorldPoint(fillerPos);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag== "menuFiller")
        {
            isStationary = true;
            //menuPlaceholder.fillerPos
            this.transform.parent = null; 
        }
        isStationary = false;
    }
}
