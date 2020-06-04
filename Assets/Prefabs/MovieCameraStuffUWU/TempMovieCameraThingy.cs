using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovieCameraThingy : MonoBehaviour
{
    public float movementSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }
}
