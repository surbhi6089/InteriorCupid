using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CameraLightEstimation : MonoBehaviour
{
    private ARCameraManager cameraManager;

    private void Awake()
    {
        cameraManager = GetComponent<ARCameraManager>();
    }

    private void OnEnable()
    {
        if (cameraManager != null)
            cameraManager.frameReceived += OnCameraFrameReceived;
    }

    private void OnDisable()
    {
        if (cameraManager != null)
            cameraManager.frameReceived -= OnCameraFrameReceived;
    }

    private void OnCameraFrameReceived(ARCameraFrameEventArgs eventArgs)
    {
        if (eventArgs.lightEstimation.averageBrightness.HasValue)
        {
            float brightness = eventArgs.lightEstimation.averageBrightness.Value;
            // Use the brightness value to adjust your AR object's materials or shaders
        }
    }
}
