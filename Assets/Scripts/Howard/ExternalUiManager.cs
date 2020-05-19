using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalUiManager : MonoBehaviour
{

    public Transform userPosition;

    private GameObject optionMenuExample;
    private GameObject telePrefab;
    private GameObject navMenuPrefab;


    void Awake()
    {
        telePrefab = Resources.Load("Prefabs/UI_Panels/Telemetry_Example") as GameObject;
        //awaiting design's approval idea
        //navMenuPrefab = Resources.Load("Prefabs/UI_Panels/") as GameObject;

        optionMenuExample = Resources.Load("Prefabs/UI_Panels/ExampleTab") as GameObject;
    }



    public void SpawnExample()
    {
         if (GameObject.Find(optionMenuExample.name + "(Clone)") == null) //checks if the panel exist in the scene
         {
            //if panel is not in the scene, spawn the panel 
            Instantiate(optionMenuExample, new Vector3(userPosition.position.x, userPosition.position.y + 0.25f, userPosition.position.z + 0.5f), Quaternion.identity);
         }
    }



    public void SpawnTelemetry()
    {
         if (GameObject.Find(telePrefab.name + "(Clone)") == null) //checks if the panel exist in the scene
         {
            //if panel is not in the scene, spawn the panel 
            Instantiate(telePrefab, new Vector3(userPosition.position.x, userPosition.position.y + 0.25f, userPosition.position.z + 0.5f), Quaternion.identity);
         }
    }



    //awaiting design's approval idea
    public void SpawnNavMenu()
    {
        if (GameObject.Find(navMenuPrefab.name + "(Clone)") == null)
        {
            Instantiate(navMenuPrefab, new Vector3(userPosition.position.x, userPosition.position.y + 0.25f, userPosition.position.z + 0.5f), Quaternion.identity);
        }
    }

}
