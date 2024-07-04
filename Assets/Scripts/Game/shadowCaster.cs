using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ShadowCaster : MonoBehaviour
{
    public GameObject lightSource; // Source de lumière
    private List<Vector3> intersectionPoints = new List<Vector3>();
    private int gridResolution = 10; // Résolution de la grille




    private GameObject[] objectsToProjectShadowsOn;

    private void Awake()
    {
        objectsToProjectShadowsOn = GameObject.FindGameObjectsWithTag("ShadowReceiver");
        intersectionPoints = RayCast();
    }
    void Update()
    {

        List<Vector3> intersectionPointsTmp = RayCast();
        if (isShapeOk(intersectionPointsTmp))
            RoatateObject.Won = true;




    }

    List<Vector3> RayCast()
    {
        List<Vector3> intersectionPointsTmp = new List<Vector3>();
        foreach (GameObject obj in objectsToProjectShadowsOn)
        {
            if (obj.TryGetComponent<BoxCollider>(out var collider))
            {
                Vector3 boundsMin = collider.bounds.min;
                Vector3 boundsMax = collider.bounds.max;
                //Debug.Log("bound " + boundsMin + " " + boundsMax);


                Debug.DrawLine(boundsMin, boundsMax, Color.green);


                // Parcourir les points de la grille
                for (int x = 0; x < gridResolution; x++)
                {
                    for (int y = 0; y < gridResolution; y++)
                    {
                        for (int z = 0; z < gridResolution; z++)
                        {
                            float minX = boundsMin.x < boundsMax.x ? boundsMin.x : boundsMax.x;
                            float maxX = boundsMin.x > boundsMax.x ? boundsMin.x : boundsMax.x;

                            float minY = boundsMin.y < boundsMax.y ? boundsMin.y : boundsMax.y;
                            float maxY = boundsMin.y > boundsMax.y ? boundsMin.y : boundsMax.y;

                            float minZ = boundsMin.z < boundsMax.z ? boundsMin.z : boundsMax.z;
                            float maxZ = boundsMin.z > boundsMax.z ? boundsMin.z : boundsMax.z;

                            // Calculer la position du point sur la grille
                            Vector3 pointOnGrid = new Vector3(
                                Mathf.Lerp(minX, maxX, (float)x / gridResolution),
                                Mathf.Lerp(minY, maxY, (float)y / gridResolution),
                                Mathf.Lerp(minZ, maxZ, (float)z / gridResolution)
                            );


                        //    Vector3 pointOnGrid = new Vector3(
                        //        Mathf.Lerp(minX - minX, maxX + maxX, (float)x / gridResolution),
                        //        Mathf.Lerp(minY - minY, maxY + maxY, (float)y / gridResolution),
                        //        Mathf.Lerp(minZ - minZ, maxZ + maxZ, (float)z / gridResolution)
                        //    );

                            // Lancer un rayon depuis la source de lumière vers le point sur la grille
                            Vector3 lightDirection = pointOnGrid - lightSource.transform.position;


                            RaycastHit hit;

                            if (Physics.Raycast(lightSource.transform.position, lightDirection, out hit, 2.0F))
                            {
                                Debug.DrawLine(lightSource.transform.position, hit.point, Color.red);
                                if (hit.collider.gameObject == obj)
                                {
                                    intersectionPointsTmp.Add(hit.point);
                                    //Debug.Log("Intersection avec : " + obj.name + " au point : " + hit.point);

                                   // Debug.DrawLine(lightSource.transform.position, hit.point, Color.blue);


                                }
                            }


                        }
                    }
                }
            }

     

        }
        return intersectionPointsTmp;
    }

    bool isShapeOk(List<Vector3> shape2)
    {
        List<Vector3> shape1 = intersectionPoints;
        // Assurez-vous que les deux formes ont le même nombre de points
        if (shape1.Count != shape2.Count)
        {
            return false;
        }

        //float totalDistance = 0f;

        //// Calculer la distance Euclidienne moyenne
        //for (int i = 0; i < shape1.Count; i++)
        //{
        //    totalDistance += Vector3.Distance(shape1[i], shape2[i]);
        //}

        //float averageDistance = totalDistance / shape1.Count;
        //if (averageDistance <= 2)
        //    return true;
        //return false;

        float diff = 0;
        for (int i = 0; i < shape1.Count - 1; i++)
        {
            diff += Mathf.Abs(Vector3.Distance(shape1[i + 1], shape1[i]) - Vector3.Distance(shape2[i + 1], shape2[i]));
            Debug.Log(diff);
            if (diff > 5)
                return false;
        }
        return true;
        //    float hausdorffDistance = CalculateHausdorffDistance(shape1, shape2);
        //if (hausdorffDistance <= 2)
        //    return true;
        //return false;
    }


    float CalculateHausdorffDistance(List<Vector3> points1, List<Vector3> points2)
    {
        float maxDistance1 = CalculateOneSidedHausdorff(points1, points2);
        float maxDistance2 = CalculateOneSidedHausdorff(points2, points1);

        return Mathf.Max(maxDistance1, maxDistance2);
    }

    float CalculateOneSidedHausdorff(List<Vector3> fromPoints, List<Vector3> toPoints)
    {
        float maxDistance = 0f;

        foreach (var fromPoint in fromPoints)
        {
            float minDistance = float.MaxValue;
            foreach (var toPoint in toPoints)
            {
                float distance = Vector3.Distance(fromPoint, toPoint);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }
            if (minDistance > maxDistance)
            {
                maxDistance = minDistance;
            }
        }

        return maxDistance;
    }
}
