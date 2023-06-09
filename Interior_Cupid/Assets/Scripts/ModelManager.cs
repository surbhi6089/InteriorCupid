using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation; //has the class ARRaycastManager and other similar classes
using UnityEngine.XR.Interaction.Toolkit.AR;


//this script manages the placement of models/objects into the real world
[RequireComponent(typeof(ARRaycastManager))]
public class ModelManager : ARBaseGestureInteractable
{
    //[SerializeField] private GameObject obj;
    [SerializeField] private Camera camera;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject pointer;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Touch touch;
    private Pose pose;

    //thisssssssssssss 

    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        if (gesture.targetObject == null)
        {
            return true;
        }
        return false;
    }

    protected override void OnEndManipulation(TapGesture gesture)
    {
        if (gesture.isCanceled)
        {
            return;
        }
        if (gesture.targetObject != null || IsTouchOnUI(gesture))
        {
            return;
        }

        if (GestureTransformationUtility.Raycast(gesture.startPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            GameObject placedObj = Instantiate(DataManager.Instance.model, pose.position, pose.rotation);

            var anchorObject = new GameObject("PlacementAnchor");
            anchorObject.transform.position = pose.position;
            anchorObject.transform.rotation = pose.rotation;
            placedObj.transform.parent = anchorObject.transform;
        }
    }

    public void FixedUpdate()
    {


        PointerCalculation();
    }

    bool IsTouchOnUI(TapGesture touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.startPosition.x, touch.startPosition.y);
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);
        return result.Count > 0;
    }

    void PointerCalculation()
    {
        Vector3 origin = camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        Ray ray = camera.ScreenPointToRay(origin);

        if (raycastManager.Raycast(ray, hits))
        {
            pose = hits[0].pose;
            pointer.transform.position = pose.position;
            pointer.transform.eulerAngles = new Vector3(90, 0, 0);
        }

    }
}
