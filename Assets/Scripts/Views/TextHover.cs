using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TextHover : MonoBehaviour
{
    public Texture2D SelectCursor;
    public UnityEngine.Color color;
    public UnityEngine.Color Hovercolor;
    private TextMesh text;

    private void Start()
    {
        
        text = GetComponent<TextMesh>();
        if (text)
            color = GetComponent<TextMesh>().color;


    }
    void OnMouseEnter()
    {
        Cursor.SetCursor(SelectCursor, Vector2.zero, CursorMode.Auto);
        if (text)
            text.color = Hovercolor;
        
    }

    void OnMouseExit()
    {
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        if (text)
            text.color = color; 
    }
}
