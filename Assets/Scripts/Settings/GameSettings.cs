using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{

    private GameObject musicObject;
    private AudioSource music;
    public static GameSettings gameSettings;
    public  static int PuzzleAchoved = 0;
    public static int Level = 3;
    public static float MusicVolume ;
    public static bool SoundEffect = true;

   

    public bool win = false;

    private void Awake()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
        if (gameSettings == null)
        {
            DontDestroyOnLoad(gameObject);
            gameSettings = this;
        }
        else if (gameSettings != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        musicObject = GameObject.FindGameObjectWithTag("GameMusic");
        if (musicObject == null)
            Debug.Log("Cannot find music");
        music = musicObject.GetComponent<AudioSource>();
        music.volume = MusicVolume;
    }



}
