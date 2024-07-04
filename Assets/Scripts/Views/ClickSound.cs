using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ClickSound : MonoBehaviour
{

    public UnityEngine.AudioSource ClickAudio;

    private void Start()
    {

        ClickAudio.time = 0.1f;
    }

    void OnMouseUp()
    {
        ClickAudio.Play(0);

    }
}
