using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//class to assign the selected item to spawn
public class DataManager : MonoBehaviour
{
    //public GameObject model;
    [SerializeField] private UIModelManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<ItemManager> items = new List<ItemManager>();

    private static DataManager instance;
    public static DataManager Instance
    {
        get {
            if (instance == null) {
                instance = FindObjectOfType<DataManager>();
            }
            return instance; 
        }
    }

    void CreateItemButton()
    {
        foreach(ItemManager i in items)
        {
            UIModelManager btn = Instantiate(buttonPrefab, buttonContainer.transform);
        }
    }
}
