using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation; //has the class ARRaycastManager and other similar classes


//this script manages the placement of models/objects into the real world
[RequireComponent(typeof(ARRaycastManager))]
public class ModelManager : MonoBehaviour
{
    //[SerializeField] private GameObject obj;
    [SerializeField] private Camera camera;
    [SerializeField] private ARRaycastManager raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Touch touch;
    [SerializeField] private GameObject pointer;
    private Pose pose;

    public void Update()
    {
        PointerCalculation();

        touch = Input.GetTouch(0);

        if(Input.touchCount<0 || touch.phase != TouchPhase.Began)
        {
            return;
        }
        if (IsTouchOnUI(touch))
        {
            return ;
        }
        
        //Instantiate(DataManager.Instance.model, pose.position, pose.rotation);

    }

    bool IsTouchOnUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);
        return result.Count > 0;
    }

    void PointerCalculation()
    {
        Vector3 origin = camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));

        //the camera reads the location of the mouse/touch position and throws a ray from that point to the AR scene, it converts the screen point to a ray
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (raycastManager.Raycast(ray, hits))
        {
            pose = hits[0].pose;
            pointer.transform.position = pose.position;
            pointer.transform.eulerAngles = new Vector3(90, 0, 0);
        }

    }
}
