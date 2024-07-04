using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTestingMode : MonoBehaviour
{
    private void OnMouseUp()
    {
        Data.isTesting = true;
        SceneManager.LoadScene(2);
    }

}
