using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningUiAnchor : MonoBehaviour
{
    public GameObject warningUi;
    

    // Update is called once per frame
    void Update()
    {
        warningUi.transform.position = this.transform.position;
    }
}
