using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleToggle : MonoBehaviour
{
    bool musicPanelVisibility = false;
    bool inventoryPanelVisibility = false;
    bool mesurementBtnVisibility = false;
    public GameObject musicPanel;
    public GameObject inventoryPanel;
    public GameObject measurementBtn;
    public void ToggleMusicPanel()
    {
        if (musicPanelVisibility == false)
        {
            if(inventoryPanelVisibility == true)
            {
                inventoryPanel.SetActive(false);
                inventoryPanelVisibility = false;
            }
            if (mesurementBtnVisibility == true)
            {
                measurementBtn.SetActive(false);
                mesurementBtnVisibility = false;
            }

            musicPanel.SetActive(true);
            musicPanelVisibility = true;
        }
        else
        {
            musicPanel.SetActive(false);
            musicPanelVisibility = false;
        }
    }
    public void ToggleInventoryPanel()
    {
        if (inventoryPanelVisibility == false)
        {
            if (musicPanelVisibility == true)
            {
                musicPanel.SetActive(false);
                musicPanelVisibility = false;
            }
            if (mesurementBtnVisibility == true)
            {
                measurementBtn.SetActive(false);
                mesurementBtnVisibility = false;
            }

            inventoryPanel.SetActive(true);
            inventoryPanelVisibility = true;
        }
        else
        {
            inventoryPanel.SetActive(false);
            inventoryPanelVisibility = false;
        }
    }
    public void ToggleMeasurementButton()
    {
        if (mesurementBtnVisibility == false)
        {
            if (inventoryPanelVisibility == true)
            {
                inventoryPanel.SetActive(false);
                inventoryPanelVisibility = false;
            }
            if (musicPanelVisibility == true)
            {
                musicPanel.SetActive(false);
                musicPanelVisibility = false;
            }

            measurementBtn.SetActive(true);
            mesurementBtnVisibility = true;
        }
        else
        {
            measurementBtn.SetActive(false);
            mesurementBtnVisibility = false;
        }
    }
}
