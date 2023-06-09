using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.AR;

//class to handle the item selection buttons/UI
public class UIModelManager : MonoBehaviour
{
    private Button btn;
    public GameObject model;
    [SerializeField] private GameObject pointer;
    //public ARPlacementInteractable placementInteractable;
    
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
        
    }
    void SelectObject()
    {
        pointer.SetActive(true);
        //placementInteractable.enabled = false;
        DataManager.Instance.model = model;
    }

}
