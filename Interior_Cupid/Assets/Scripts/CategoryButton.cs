using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class CategoryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public CategoryGroup categoryGroup;
    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {
        categoryGroup.OnCategorySelected(this);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        categoryGroup.OnCategoryEnter(this);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        categoryGroup.OnCategoryExit(this);

    }

    void Start()
    {
        background = GetComponent<Image>();
        categoryGroup.Subscribe(this);
    }
}
