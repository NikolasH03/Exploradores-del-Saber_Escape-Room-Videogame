using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameManager : MonoBehaviour
{
    public GameObject cellPrefab; // Prefab de las celdas
    public Transform gridParent; // Padre de la cuadrícula
    public Sprite[] mushroomImages; // Array de imágenes para los hongos
    public Sprite defaultSprite; // Sprite por defecto para las celdas

    private List<Button> cells = new List<Button>();
    private List<int> mushroomIndices = new List<int>();

    private int firstSelectedIndex = -1; // Índice de la primera celda seleccionada
    private int secondSelectedIndex = -1; // Índice de la segunda celda seleccionada

    void Start()
    {
        SetupGame();
    }

    void SetupGame()
{
    mushroomIndices.Clear();
    cells.Clear();

    // Crear 6 pares de índices
    for (int i = 0; i < 6; i++)
    {
        mushroomIndices.Add(i);
        mushroomIndices.Add(i);
    }

    // Mezclar los índices
    ShuffleList(mushroomIndices);

    // Crear las celdas
    for (int i = 0; i < 12; i++)
    {
        GameObject cell = Instantiate(cellPrefab, gridParent);
        Button cellButton = cell.GetComponent<Button>();

        if (cellButton == null)
        {
            Debug.LogError($"La celda {i} no tiene el componente Button.");
            continue;
        }

        // Configurar la celda
        cells.Add(cellButton);

        // Asignar sprite por defecto
        Image cellImage = cell.GetComponent<Image>();
        if (cellImage != null)
        {
            cellImage.sprite = defaultSprite; // Asignar sprite por defecto aquí
        }
        else
        {
            Debug.LogError($"La celda {i} no tiene un componente Image.");
        }

        // Asignar evento de clic
        int index = i;
        cellButton.onClick.AddListener(() => OnCellClicked(index));
    }

    Debug.Log($"Número de celdas creadas: {cells.Count}");
}
    void ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

 void OnCellClicked(int index)
{
    // Evitar seleccionar más de dos celdas
    if (firstSelectedIndex != -1 && secondSelectedIndex != -1)
        return;

    // Verificar si la celda ya está desactivada o es la misma que ya se seleccionó
    if (!cells[index].interactable || index == firstSelectedIndex)
        return;

    // Revelar el contenido
    Button cellButton = cells[index];
    Image cellImage = cellButton.GetComponent<Image>();

    if (cellImage != null)
    {
        cellImage.sprite = mushroomImages[mushroomIndices[index]];
    }
    else
    {
        Debug.LogError($"La celda {index} no tiene un componente Image.");
        return;
    }

    // Actualizar el texto de la celda seleccionada
    Text cellText = cellButton.GetComponentInChildren<Text>();
    if (cellText != null)
    {
        if (firstSelectedIndex == -1)
        {
            firstSelectedIndex = index;
            cellText.text = "1"; // Primera selección
        }
        else if (secondSelectedIndex == -1)
        {
            secondSelectedIndex = index;
            cellText.text = "2"; // Segunda selección
            CheckMatch();
        }
    }
}

    void CheckMatch()
    {
        if (firstSelectedIndex < 0 || secondSelectedIndex < 0)
        {
            Debug.LogError("Índices inválidos en CheckMatch.");
            return;
        }

        if (mushroomIndices[firstSelectedIndex] == mushroomIndices[secondSelectedIndex])
        {
            Debug.Log("¡Pareja encontrada!");
            cells[firstSelectedIndex].interactable = false;
            cells[secondSelectedIndex].interactable = false;
        }
        else
        {
            Debug.Log("No coinciden.");
            StartCoroutine(HideCells());
        }

        // Reiniciar índices al final
        firstSelectedIndex = -1;
        secondSelectedIndex = -1;
    }

   IEnumerator HideCells()
{
    yield return new WaitForSeconds(1);

    if (firstSelectedIndex >= 0 && firstSelectedIndex < cells.Count)
    {
        cells[firstSelectedIndex].GetComponent<Image>().sprite = defaultSprite;
        Text cellText = cells[firstSelectedIndex].GetComponentInChildren<Text>();
        if (cellText != null) cellText.text = ""; // Limpiar texto
    }

    if (secondSelectedIndex >= 0 && secondSelectedIndex < cells.Count)
    {
        cells[secondSelectedIndex].GetComponent<Image>().sprite = defaultSprite;
        Text cellText = cells[secondSelectedIndex].GetComponentInChildren<Text>();
        if (cellText != null) cellText.text = ""; // Limpiar texto
    }

    firstSelectedIndex = -1;
    secondSelectedIndex = -1;
}
}
