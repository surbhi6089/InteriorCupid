using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
public class ControlPlaneDetection : MonoBehaviour
{
    private ARPlaneManager planeManager;
    [SerializeField] private Text controlButtonText;
    [SerializeField] private GameObject pointer;


    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        controlButtonText.text = "Disable";
    }

    public void ControlDetectedPlanes()
    {
        planeManager.enabled = !planeManager.enabled;
        string controlButtonMessage = " ";

        if (planeManager.enabled && pointer.activeSelf != true)
        {
            controlButtonMessage = "Disable";
            SetPlanesActive(true);
            pointer.SetActive(true);
        }
        else
        {
            controlButtonMessage = "Enable";
            SetPlanesActive(false);
            pointer.SetActive(false);
        }

        controlButtonText.text = controlButtonMessage;
    }

    public void SetPlanesActive(bool value)
    {
        foreach(var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}
