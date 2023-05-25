using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class MeasurementObjPlacement : MonoBehaviour
{
    public Button placementButton;
    public ARPlacementInteractable placementInteractable;
    [SerializeField] private GameObject pointer;

    private void Start()
    {
        pointer.SetActive(false);
        placementButton.onClick.AddListener(EnablePlacementInteractable);
    }

    public void EnablePlacementInteractable()
    {
        placementInteractable.enabled = true;
        Debug.Log("Enabled");
    }
}
