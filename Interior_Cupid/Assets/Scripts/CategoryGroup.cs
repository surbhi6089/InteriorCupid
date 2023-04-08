using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CategoryGroup : MonoBehaviour
{
    public List<CategoryButton> categoryButtons;
    public Sprite categoryIdle;
    public Sprite categoryActive;
    public CategoryButton selectedCategory;
    public List<GameObject> objectsToSwap;

    public void Subscribe(CategoryButton button)
    {
        if(categoryButtons == null)
        {
            categoryButtons = new List<CategoryButton>();
        }
        categoryButtons.Add(button);
    }

    public void OnCategoryEnter(CategoryButton button)
    {
        ResetCategories();
        //if(selectedCategory == null || button != selectedCategory)
        //{

        //}
    }

    public void OnCategoryExit(CategoryButton button)
    {
        ResetCategories();
    }

    public void OnCategorySelected(CategoryButton button)
    {
        selectedCategory = button;
        ResetCategories();
        button.background.sprite = categoryActive;

        int index = button.transform.GetSiblingIndex();
        for(int i=0; i<objectsToSwap.Count; i++)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetCategories()
    {
        foreach(CategoryButton button in categoryButtons)
        {
            if(selectedCategory!=null && button == selectedCategory)
            {
                continue;
            }
            button.background.sprite = categoryIdle;
        }
    }
}
