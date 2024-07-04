using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicMenu : MonoBehaviour
{
    public static MusicMenu musicMenu;

    private void Awake()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
        
            
        if (musicMenu == null && gameObject)
        {
            DontDestroyOnLoad(gameObject);
            musicMenu = this;
        }
        else if (musicMenu != this)
        {
            Destroy(gameObject);
        }
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Scene sceneLoaded = SceneManager.GetActiveScene();
        Debug.Log("scene" + sceneLoaded.buildIndex);
        if (sceneLoaded.buildIndex > 2 && gameObject)
        {
            Destroy(gameObject);
            return;
        }
    }


}