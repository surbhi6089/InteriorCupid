using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//class to handle the item selection buttons/UI
public class UIModelManager : MonoBehaviour
{
    private Button btn;
    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
        
    }
    void SelectObject()
    {
       DataManager.Instance.model = model;
    }

}
