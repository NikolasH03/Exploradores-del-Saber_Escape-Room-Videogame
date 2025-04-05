using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        // Destruir los elementos anteriores del inventario UI
        foreach (Transform child in itemSlotContainer)
        {
            if (child != itemSlotTemplate && child != null)
            {
                Destroy(child.gameObject);
            }
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 100f;

        // Generar nuevos elementos para el inventario
        foreach (Item item in inventory.GetItemList())
        {
            if (item == null) continue;

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            // Asegurarse de que no sea nulo antes de acceder
            if (itemSlotRectTransform != null)
            {
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

                Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();

                if (image != null)
                {
                    image.sprite = item.GetSprite();
                }
                itemSlotRectTransform.gameObject.tag = item.itemType.ToString();

                y--;
                if (y < -4)
                {
                    y = 0;
                    x++;
                }
            }
        }
    }
}

