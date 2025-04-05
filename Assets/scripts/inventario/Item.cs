using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        llave = 1,
        lente = 2,
        hongo = 3,
        fusible = 4,
        llaveFinal = 5,
    }

    public ItemType itemType;
    public int itemID;

    public Item(ItemType itemType)
    {
        this.itemType = itemType;
        this.itemID = (int)itemType; // Asignamos el ID basado en el tipo de objeto
    }

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.llave: return ItemAssets.Instance.llave;
            case ItemType.lente: return ItemAssets.Instance.lente;
            case ItemType.hongo: return ItemAssets.Instance.hongo;
            case ItemType.fusible: return ItemAssets.Instance.fusible;
            case ItemType.llaveFinal: return ItemAssets.Instance.llaveFinal;
        }
    }

    public int GetItemID()
    {
        return itemID;
    }
}

