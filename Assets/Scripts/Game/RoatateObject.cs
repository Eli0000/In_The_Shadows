
using System.Collections;
using UnityEngine;


public class RoatateObject : MonoBehaviour
{

    public Quaternion WinRotationMin;
    public Quaternion WinRotationMax;
    public Quaternion StartRotation;
    public Vector3 StartPosition;
    public Vector3 WinPositionMin;
    public Vector3 WinPositionMax;
    public AudioSource LightSound;
    public Texture2D CursorRotateX;
    public Texture2D CursorRotateY;
    public Texture2D CursorTranslate;
    public int puzzleLevel;


    private bool WonCoroutin = false;
    private float scrollValueX;
    private float scrollValueY;
    private float mouveValueX;
    private float mouveValueY;
    private Quaternion rotation;
    private Vector3 position;
    private bool isMouseOver = false;
    private bool isMouseDown = false;
    private bool isCtrlDown = false;
    private bool isShiftDown = false;
    private Light SpotLight;
    public static bool Won = false;
    private GameObject Popup;


    private void Awake()
    {
        Popup = GameObject.FindGameObjectWithTag("WinPopup");
        if (Popup == null)
            Debug.Log("WinPopup not found");
        else
            Popup.SetActive(false);
    }
    private void Start()
    {
        //Debug.Log("Start Rotation" + StartRotation);
        transform.rotation = StartRotation;
        GameObject lightObject = GameObject.FindGameObjectWithTag("SpotLight");
        if (lightObject == null)
        {
            Debug.Log("Cannot find object with Tag SpotLight");
        }
        else
        {
            SpotLight = lightObject.GetComponent<Light>();
        }
        LightSound = GetComponent<AudioSource>();
        LightSound.time = 0.1f;
        if (LightSound == null)
        {
            Debug.Log("Cannot find object Audio Source in MouveObject");
        }
     

    }



    

    private void Update()
    {

        if (Won)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            if (!WonCoroutin)
                StartCoroutine(Win());
            return;
        }
        if (isMouseOver)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                isCtrlDown = true;
                Cursor.SetCursor(CursorRotateY, Vector2.zero, CursorMode.Auto);
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                isShiftDown = true;
                Cursor.SetCursor(CursorTranslate, Vector2.zero, CursorMode.Auto);

            }
        }


        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            isCtrlDown = false;
            if (isMouseOver)
                Cursor.SetCursor(CursorRotateX, Vector2.zero, CursorMode.Auto);

        }

        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            isShiftDown = false;
            if (isMouseOver)
                Cursor.SetCursor(CursorRotateX, Vector2.zero, CursorMode.Auto);
        }

        if (isMouseOver && isMouseDown)
        {
            if (GameSettings.Level > 1 & isCtrlDown)
            {
                scrollValueY = Input.GetAxis("Mouse Y");
                transform.Rotate(Vector3.left, scrollValueY * 50); // Rotation sur l'axe Y
            }
            else if (GameSettings.Level == 3 & isShiftDown)
            {
                Vector3 currentPosition = transform.position;
                Vector3 translateVector = new(Input.GetAxis("Mouse X") * -0.5F,Input.GetAxis("Mouse Y") * 0.5F, 0);
                Vector3 newPosition = currentPosition + translateVector;
                newPosition.z = currentPosition.z;
                transform.position = newPosition;

            }
            else
            {
                scrollValueX = Input.GetAxis("Mouse X");
                transform.Rotate(Vector3.up, scrollValueX * -50);
            }
        }
        rotation = transform.rotation;

        //Debug.Log("\n");
        //Debug.Log(rotation);
        //Debug.Log(WinRotationMin);
        //Debug.Log(WinRotationMax);
        //Debug.Log("\n");

        //if (rotation.x >= WinRotationMin.x && rotation.y >= WinRotationMin.y
        //        && rotation.x <= WinRotationMax.x && rotation.y <= WinRotationMax.y)
        //{
        //    Debug.Log("Win");
        //    if (puzzleLevel != 3)
        //        StartCoroutine(Win());
        //    else
        //        position = transform.position;
        //    if (position.x >= WinPositionMin.x && position.y >= WinPositionMin.y && position.z >= WinPositionMin.z
        //        && position.x <= WinPositionMax.x && position.y <= WinPositionMax.y && position.z >= WinPositionMax.z)
        //        StartCoroutine(Win());

        //}
    
    }

    public IEnumerator Win()
    {
        WonCoroutin = true;
        Won = true;
        LightSound.Play(0);
        for (int i = 0; i < 10; i += 1)
        {

            SpotLight.intensity += 2;
            yield return new WaitForSeconds(0.2F);
        }

        foreach (Transform child in transform)
        {
            MeshRenderer[] ChildMeshRenderer = child.GetComponentsInChildren<MeshRenderer>();
            MeshRenderer[] MeshRendererr  = child.GetComponents<MeshRenderer>();
            SkinnedMeshRenderer[] skinnedMeshRenderer = child.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (MeshRenderer elem in MeshRendererr)
                elem.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            foreach (MeshRenderer elem in ChildMeshRenderer)
                elem.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            foreach (SkinnedMeshRenderer elem in skinnedMeshRenderer)
                elem.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;


        }
         if (Popup)
            Popup.SetActive(true);

         GameObject[] ToRemove = GameObject.FindGameObjectsWithTag("ToRemove");

        foreach (GameObject elem in ToRemove)
            elem.SetActive(false);

    }

    private void OnMouseDown()
    {

        isMouseDown = true;


    }
    private void OnMouseUp()
    {
        isMouseDown= false;
    }

    private void OnMouseEnter()
    {

        isMouseOver = true;
        Cursor.SetCursor(CursorRotateX, Vector2.zero, CursorMode.Auto);

    }
    private void OnMouseExit()
    {
        isMouseOver = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }


}

