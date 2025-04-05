using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemWorld : MonoBehaviour
{
    [SerializeField] private int itemID; // Nuevo: ID asignable desde el Inspector
    private Item item;

    private void Awake()
    {
        // Crear un nuevo Item basado en el itemID
        item = CreateItemFromID(itemID);
    }

    private Item CreateItemFromID(int id)
    {
        // Dependiendo del ID, asignamos el tipo de objeto
        switch (id)
        {
            case 1: return new Item(Item.ItemType.llave);
            case 2: return new Item(Item.ItemType.lente);
            case 3: return new Item(Item.ItemType.hongo);
            case 4: return new Item(Item.ItemType.fusible);
            case 5: return new Item(Item.ItemType.llaveFinal);
            default:
                Debug.LogWarning("ID de objeto no válido: " + id);
                return null;
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public int GetItemID()
    {
        return itemID;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}



