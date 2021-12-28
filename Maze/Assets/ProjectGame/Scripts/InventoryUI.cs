using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Image> icons = new List<Image>();
    private float timeToHide;
    public void UpdateUI(Inventory inventory)
    {
        var canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        for (var i = 0; i < inventory.GetSize(); i++)
        {
            if (inventory.GetItem(i) == null)
            {
                icons[i].sprite = null;
                icons[i].color = new Color(icons[i].color.r, icons[i].color.g, icons[i].color.b, 0);
            }
            else
            {
                icons[i].sprite = inventory.GetItem(i).icon;
                icons[i].color = new Color(icons[i].color.r, icons[i].color.g, icons[i].color.b, 255);
            }
        }
    }

    public void Update()
    {
        var canvasGroup = gameObject.GetComponent<CanvasGroup>();
        if (canvasGroup.alpha > 0)
        {
            timeToHide += Time.deltaTime;
            if (timeToHide >= 3)
                canvasGroup.alpha -= Time.deltaTime;
        }
        else
        {
            timeToHide = 0;
        }
    }
}
