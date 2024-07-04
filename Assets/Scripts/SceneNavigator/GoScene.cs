using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoScnene : MonoBehaviour
{

    public int goScene;

    void OnMouseUp()
    {

        SceneManager.LoadScene(goScene);
    }

}