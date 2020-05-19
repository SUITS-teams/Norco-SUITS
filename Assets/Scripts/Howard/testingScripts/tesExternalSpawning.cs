using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tesExternalSpawning : MonoBehaviour
{
    public ExternalUiManager ui;

    // Start is called before the first frame update
    void Update()
    {
        ui.SpawnTelemetry();
    }
}
