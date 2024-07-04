using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZeroToOne : MonoBehaviour
{

    public bool isNormal;
    public bool isTest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseUp()
    {
        if (isNormal)
        {
            SceneManager.LoadScene(1);

        }
        if (isTest)
        {
            
            SceneManager.LoadScene(1);
        }
    }
}
