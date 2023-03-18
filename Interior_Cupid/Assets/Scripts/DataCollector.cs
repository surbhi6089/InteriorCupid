using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollector : MonoBehaviour
{
    public GameObject model;

    private static DataCollector instance;
    public static DataCollector Instance
    {
        get {
            if (instance == null) {
                instance = FindObjectOfType<DataCollector>();
            }
            return instance; 
        }
    }
}
