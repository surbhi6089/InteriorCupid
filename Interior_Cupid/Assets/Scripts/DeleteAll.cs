using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DeleteAll : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;

    public void RemoveARObjects()
    {
        GameObject[] placedObjects = GameObject.FindGameObjectsWithTag("ARObject");

        foreach (GameObject placedObject in placedObjects)
        {
            Destroy(placedObject);
        }
    }
}
