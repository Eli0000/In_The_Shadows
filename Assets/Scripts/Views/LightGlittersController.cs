
using System.Collections;
using UnityEngine;
using System;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {


        StartCoroutine(Glitter());

    }



    IEnumerator Glitter()
    {
       
        if (!TryGetComponent<Light>(out var light))
        {
            Debug.LogWarning("Aucun composant light trouvé sur l'objet Firefly_light!");
            yield return -1;
            
        }
        light = GetComponent<Light>();
        float lightRange =  light.range;
      
        float growValue = lightRange / 35;
        System.Random rnd = new System.Random();
       
        while (true){
            float randTime = Random.Range(0.2f, 0.6f);
            int randIt = rnd.Next(4, 10);
            for (int i = 0; i < randIt; i++)
            {
                float curLightRange = GetComponent<Light>().range;
                GetComponent<Light>().range = curLightRange + growValue;

                // Si vous voulez voir l'effet de manière fluide, ajoutez un délai ici
                yield return new WaitForSeconds(randTime / 10f);
            }
            for (int i = 0; i < randIt; i++)
            {
                float curLightRange = GetComponent<Light>().range;
                GetComponent<Light>().range = curLightRange - growValue;

                // Si vous voulez voir l'effet de manière fluide, ajoutez un délai ici
                yield return new WaitForSeconds(randTime / 10f);
            }
         

        }
    }
}


