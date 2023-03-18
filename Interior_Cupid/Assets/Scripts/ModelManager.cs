using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; //has the class ARRaycastManager and other similar classes

//this script manages the placement of models/objects into the real world
[RequireComponent(typeof(ARRaycastManager))]
public class ModelManager : MonoBehaviour
{
    //[SerializeField] private GameObject obj;
    [SerializeField] private Camera camera;
    [SerializeField] private ARRaycastManager raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //the camera reads the location of the mouse/touch position and throws a ray from that point to the AR scene, it converts the screen point to a ray
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (raycastManager.Raycast(ray, hits))
            {
                Pose pose = hits[0].pose;
                Instantiate(DataCollector.Instance.model, pose.position, pose.rotation);
            }
        }
    }
}
