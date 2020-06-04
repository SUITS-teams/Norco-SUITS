using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dynamicTextpt2ElectricBoogaloo : MonoBehaviour
{
    private TextMeshProUGUI dataStream;//telemmetry panel specifies ui text so we use tmprougui instead of just tmpro
    private int data;
    
    // Start is called before the first frame update
    void Start()
    {
        dataStream = gameObject.GetComponent<TextMeshProUGUI>();
        data = 0;
        //start data value at 0 for iteration
    }

    // Update is called once per frame
    void Update()
    {
        //data += Random.Range(0, 100); //puts out unrealistic values so we'll use system.random instead
        System.Random rand = new System.Random(); // using system.random for the next method to set a better range for acceptable values
         data = rand.Next(0, 100);
        dataStream.SetText(data.ToString()); // more efficient way to convert from int to string for tmp ui

        ;

    }
   
    }


