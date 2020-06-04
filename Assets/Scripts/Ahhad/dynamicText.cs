using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;// allows us to use the textmesh editor function;

public class dynamicText : MonoBehaviour
{
    private TextMeshPro dataStream;
    //private TextMesh dataStream;
    private int data;
    // Start is called before the first frame update
    void Start()
    {
         dataStream = gameObject.GetComponent<TextMeshPro>();
       // dataStream = gameObject.GetComponent<TextMesh>();
        data = 0;
        //start data value at 0 for iteration
    }

    // Update is called once per frame
    void Update()
    {
        // dataStream.text = data.ToString();//converting the int to string 


        for (int i = 0; i < 200; i++) {
            data += Random.Range(-1, 1);
           // dataStream.text = data.ToString();//converting the int to string 
            dataStream.SetText(data.ToString());
        }
        // make data iterate until reaching 100
    }
}
