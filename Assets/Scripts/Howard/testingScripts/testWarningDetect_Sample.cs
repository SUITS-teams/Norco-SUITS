using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWarningDetect_Sample : MonoBehaviour
{
    public WarningDisplay warning;

    // Update is called once per frame
    void Start()
    {
        warning.displayIcon_Oxygen(true);
        warning.displayIcon_Water(true);
        warning.displayIcon("Power", true);
    }
}
