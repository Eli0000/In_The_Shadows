using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering;

public class MusicVolume : MonoBehaviour
{

   
    public Texture2D CursorSelect;
    public BoxCollider Collider;
    public UnityEngine.Sprite VolumeIcon;
    public UnityEngine.Sprite VolumeIconMute;

    private AudioSource[] musics;
    private GameObject round;
    private AudioSource music;
    public RectTransform uiElement;
    private Vector2 size;
    private float volume;
    private GameObject volumeIconObj;
    private UnityEngine.SpriteRenderer sprite;
    




    void Start()
    {

        round = GameObject.FindGameObjectWithTag("RoundVolumeBar");
        if (round == null)
            Debug.Log("Cannot find Round volume on bar");

        musics = FindObjectsOfType<AudioSource>();

        volumeIconObj = GameObject.FindGameObjectWithTag("IconVolumeBar");
        if (volumeIconObj == null)
            Debug.Log("Cannot find volume bar icon.");
        sprite = volumeIconObj.GetComponent<SpriteRenderer>();



        size = uiElement.sizeDelta;

    //    round.transform.localPosition = new(-size.x / GameSettings.MusicVolume, 0);
        Collider.center = round.transform.localPosition;


    }



    private void OnMouseDrag()
    {
        float scrollValueX = Input.GetAxis("Mouse X");
        Vector3 translate = new(-scrollValueX, 0);

 
        if ((round.transform.localPosition.x >= 0 && scrollValueX < 0) || (Mathf.Abs(round.transform.localPosition.x) >= size.x && scrollValueX > 0))
            return;
        round.transform.Translate(translate);
        if (round.transform.localPosition.x > 0)
            round.transform.localPosition = new(0, 0);
        else if (Mathf.Abs(round.transform.localPosition.x) > size.x)
        {
            round.transform.localPosition = new(-size.x, 0);
        }

        Collider.center = round.transform.localPosition;

        volume = 1 - ((size.x + round.transform.localPosition.x)/ size.x) ;

        foreach (AudioSource music in musics)
            music.volume = volume;

        if (volume < 0.1F)
            sprite.sprite = VolumeIconMute;
        else
            sprite.sprite = VolumeIcon;



    }


    private void OnMouseEnter()
    {
        
        Cursor.SetCursor(CursorSelect, Vector2.zero, CursorMode.Auto);

    }
    private void OnMouseExit()
    {
        
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        GameSettings.MusicVolume = volume;
    }

}
