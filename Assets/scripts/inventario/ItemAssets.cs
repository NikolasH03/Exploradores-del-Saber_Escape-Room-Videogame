using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
 public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite llave;
    public Sprite hongo;
    public Sprite lente;
    public Sprite fusible;
    public Sprite llaveFinal;
}
