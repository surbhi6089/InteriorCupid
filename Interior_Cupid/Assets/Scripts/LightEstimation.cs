using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class LightEstimation : MonoBehaviour
{
    private Renderer objectRenderer;
    private ARCameraManager cameraManager;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        cameraManager = FindObjectOfType<ARCameraManager>();
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
        ARLightEstimationData lightEstimation = eventArgs.lightEstimation;

        if (lightEstimation.averageBrightness.HasValue)
        {
            float brightness = lightEstimation.averageBrightness.Value;
            // Use the brightness value to adjust your AR object's materials or shaders
        }

        if (lightEstimation.colorCorrection.HasValue)
        {
            Color colorCorrection = lightEstimation.colorCorrection.Value;
            if (objectRenderer != null)
                objectRenderer.material.SetColor("_ColorCorrection", colorCorrection);
        }
    }
}
