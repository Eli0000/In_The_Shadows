using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class TextMeshFader : MonoBehaviour
{
    public TextMesh text;



    void Start()
    {
        if (!TryGetComponent<TextMesh>(out text))
        {
            Debug.LogError("TextMesh component is not assigned and not found on the GameObject.");
            return;
        }
        StartCoroutine(FadeOutCR());

    }



    IEnumerator FadeOutCR()
    {
        float duration = 4;
        for (int i = 0; i < 20; i++)
        {
            Color originalColor = text.color;
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a - 1/20F);
            // Si vous voulez voir l'effet de manière fluide, ajoutez un délai ici
            yield return new WaitForSeconds(duration / 20);
        }
        Data.isTesting = true;
        SceneManager.LoadScene(1);
        yield break;
    }
}
