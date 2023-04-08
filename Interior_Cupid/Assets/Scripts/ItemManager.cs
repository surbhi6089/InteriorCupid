using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//class to help persist item/model data
[CreateAssetMenu(fileName = "Item1", menuName = "Add Item/Item")]
public class ItemManager : ScriptableObject
{
    public GameObject Prefab;
    public Sprite Image;
}
