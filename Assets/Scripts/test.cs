using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Data.isTesting == true)
            Debug.LogWarning("Testing Mode");
        else
            Debug.LogWarning("Normal Mode");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
