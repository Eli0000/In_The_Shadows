using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering;

public class SoundEffect : MonoBehaviour
{


    private TextMesh text;
    private GameObject[] musicObject;
    private List<AudioSource> musics = new();



    void Start()
    {


        musicObject = GameObject.FindGameObjectsWithTag("EffectSound");
        if (musicObject == null)
            Debug.Log("Cannot find music");
        foreach (GameObject elem in musicObject)
        {
            AudioSource audio = elem.GetComponent<AudioSource>();
            musics.Add(audio);
        }
        if (!gameObject.TryGetComponent(out text))
            Debug.Log("Cannot find text");



    }


    private void OnMouseUp()
    {
       
        if (GameSettings.SoundEffect == true)
        {
            GameSettings.SoundEffect =false;
            text.text = "Off";
            foreach (AudioSource elem in musics)
                elem.mute = true;

        }
        else
        {
            GameSettings.SoundEffect = true;
            text.text = "On";
            foreach (AudioSource elem in musics)
                elem.mute = false;

        }
    }
}
