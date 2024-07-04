using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectNormalMode : MonoBehaviour
{
    private void OnMouseUp()
    {
        Data.isTesting = false;
        SceneManager.LoadScene(2);
    }
     
}
