using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public GameObject cellPrefab; // Prefab de las celdas
    public Transform gridParent; // Donde se colocará la cuadrícula
    private List<Button> cells = new List<Button>();

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int i = 0; i < 12; i++) // 4x3 = 12 celdas
        {
            GameObject cell = Instantiate(cellPrefab, gridParent);
            cells.Add(cell.GetComponent<Button>());
        }
    }
}