using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalUiManager : MonoBehaviour
{
    public Transform cameraPosition;

    private GameObject optionMenuExample;
    private GameObject telePrefab;
    private GameObject settingPrefab;
    private GameObject virtualModelPrefab;
    

    void Awake()
    {
        string prefabFolderPath = "Prefabs/UI_Panels/"; //folder pathway turned into a variable in case of change

        telePrefab = Resources.Load(prefabFolderPath + "Telemetry_Example") as GameObject;
        settingPrefab = Resources.Load(prefabFolderPath + "SettingsPanel") as GameObject;
        optionMenuExample = Resources.Load(prefabFolderPath + "ExampleTab") as GameObject;
        virtualModelPrefab = Resources.Load(prefabFolderPath + "") as GameObject;
    }



    public void SpawnExample()
    {
         if (GameObject.Find(optionMenuExample.name + "(Clone)") == null) //checks if the panel exist in the scene
         {
            //if panel is not in the scene, spawn the panel 
            Instantiate(optionMenuExample, new Vector3(cameraPosition.position.x - 0.5f, cameraPosition.position.y + -0.25f, cameraPosition.position.z), Quaternion.identity, this.transform);
            this.transform.Find(optionMenuExample.name + "(Clone)").gameObject.SetActive(true);
         }
    }



    public void SpawnTelemetry()
    {
         if (GameObject.Find(telePrefab.name + "(Clone)") == null) //checks if the panel exist in the scene
         {
            //if panel is not in the scene, spawn the panel 
            Instantiate(telePrefab, new Vector3(cameraPosition.position.x - 0.5f, cameraPosition.position.y + -0.25f, cameraPosition.position.z), Quaternion.identity, this.transform);
            this.transform.Find(telePrefab.name + "(Clone)").gameObject.SetActive(true);
         }
    }



    public void SpawnSetting()
    {
        if (GameObject.Find(settingPrefab.name + "(Clone)") == null) //checks if the panel exist in the scene
        {
            //if panel is not in the scene, spawn the panel 
            Instantiate(settingPrefab, new Vector3(cameraPosition.position.x - 0.5f, cameraPosition.position.y - 0.25f, cameraPosition.position.z), Quaternion.identity, this.transform);
            this.transform.Find(settingPrefab.name + "(Clone)").gameObject.SetActive(true);
        }
    }



    //WIP
    public void SpawnVirtualModel()
    {
        if (GameObject.Find(virtualModelPrefab.name + "(Clone)") == null) //checks if the panel exist in the scene
        {
            //if panel is not in the scene, spawn the panel 
            Instantiate(virtualModelPrefab, new Vector3(cameraPosition.position.x - 0.5f, cameraPosition.position.y - 0.25f, cameraPosition.position.z), Quaternion.identity, this.transform);
            this.transform.Find(virtualModelPrefab.name + "(Clone)").gameObject.SetActive(true);
        }
    }
}
