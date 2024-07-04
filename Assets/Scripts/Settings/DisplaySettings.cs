using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering;

public class DisplaySettings : MonoBehaviour
{
    private GameObject Menu;




    void Start()
    {


        Menu = GameObject.FindGameObjectWithTag("MenuSettings");
        if (Menu == null)
            Debug.Log("Cannot find music");
        else
            Menu.SetActive(false);



    }


    private void OnMouseUp()
    {

        Menu.SetActive(!Menu.activeSelf);
    }
}
