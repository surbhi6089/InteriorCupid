using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; //has the class ARRaycastManager and other similar classes
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObject : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private Camera camera;
    [SerializeField] private ARRaycastManager raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit> ();

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(raycastManager.Raycast(ray, hits))
            {
                Pose pose = hits[0].pose;
                Instantiate(obj, pose.position, pose.rotation);
            }
        }
    }







    //public void Awake()
    //{
    //    m_RaycastManager = GetComponent<ARRaycastManager>();
    //}

    //bool GetTouchPosition(out Vector2 touchPosition)
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        touchPosition = Input.GetTouch(0).position;
    //        return true;
    //    }
    //    touchPosition = default;
    //    return false;
    //}

    //private void Update()
    //{
    //    if(!GetTouchPosition(out Vector2 touchPosition))
    //    {
    //        return;
    //    }

    //    if(m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
    //    {
    //        var hitPose = s_Hits[0].pose;
    //        if (obj == null)
    //        {
    //            obj = Instantiate(PlaceablePrefab, hitPose.position, hitPose.rotation);
    //        }
    //        else
    //        {
    //            obj.transform.position = hitPose.position;
    //            obj.transform.rotation = hitPose.rotation;
    //        }
    //    }
    //}
}
