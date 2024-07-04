using UnityEngine;

public class DrawLineTest : MonoBehaviour
{
    void Update()
    {
        // Point de départ de la ligne
        Vector3 startPoint = new Vector3(1.6773798e-07F, 0, 8);
        // Point d'arrivée de la ligne
        Vector3 endPoint = new Vector3(0, -0.0929999948F, 7.13500023F);

        // Dessiner une ligne rouge avec une durée de 5 secondes
        Vector3 direction = new Vector3(10, 10, 10);
      //  Debug.DrawLine(startPoint, endPoint, Color.red, 20.0f);
        Debug.DrawRay(startPoint, direction, Color.red, 10.0f);
        Debug.Log("Rayon dessiné de (0, 0, 0) dans la direction (10, 10, 10)");
    }
}