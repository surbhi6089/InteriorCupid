using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DeleteAll : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public LineRenderer lineRenderer;

    public void RemoveARObjects()
    {
        GameObject[] placedObjects = GameObject.FindGameObjectsWithTag("ARObject");

        foreach (GameObject placedObject in placedObjects)
        {
            Destroy(placedObject);
        }

        GameObject[] placedPoints = GameObject.FindGameObjectsWithTag("Point");

        foreach (GameObject placedPoint in placedPoints)
        {
            Destroy(placedPoint);
        }
        Destroy(lineRenderer);
    }
}
