using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UI_inventory uiInventory;
    private itemWorld currentItem;
    public GameObject textos;
    TextMeshProUGUI textMesh;

    public FlujoJuego flujoJuego;
    public GameObject llaveCicloVida;
    public GameObject fusible;
    public GameObject llaveFinal;
    public DoorController DC;

    [SerializeField] AudioSource sfxSource;
    public AudioClip item;
    private void Start()
    {
       textMesh = textos.GetComponent<TextMeshProUGUI>();
        textos.SetActive(false);
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        //if (GameManager.Instance != null && GameManager.Instance.playerPosition != Vector3.zero)
        //{
        //    transform.position = GameManager.Instance.playerPosition;
        //}
    }

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.GetComponent<itemWorld>() != null)
        {
            textMesh.text = "Presiona 'E' para obtener el Item";
            textos.SetActive(true);
            currentItem = collider.GetComponent<itemWorld>(); 
        }
       
    }

    private void OnTriggerExit(Collider collider)
    {
        textos.SetActive(false);
        if (collider.GetComponent<itemWorld>() != null)
        {
            currentItem = null; 
        }
    }

    private void Update()
    {

        if (currentItem != null && Input.GetKeyDown(KeyCode.E))
        {
            textos.SetActive(false);


            inventory.AddItem(currentItem.GetItem());
            currentItem.DestroySelf();
            currentItem = null;
            sfxSource.PlayOneShot(item);
            DC.numberKeys++;
            if (DC.numberKeys == 3)
            {
                DC.gotKey = true;
            }

        }
    }

    public void nuevoItem(int tipoItem)
    {
        if(tipoItem == 1)
        {
            currentItem = llaveCicloVida.GetComponent<itemWorld>();
            flujoJuego.preparadoCicloRana = true;
        } 
        else if(tipoItem == 2)
        {
            currentItem = fusible.GetComponent<itemWorld>();
            flujoJuego.preparadoSimon = true;
        }
        else if (tipoItem == 3)
        {
            currentItem = llaveFinal.GetComponent<itemWorld>();

            DC.numberKeys++;
            if (DC.numberKeys == 3)
            {
                DC.gotKey = true;
            }
        }
        sfxSource.PlayOneShot(item);
        //textMesh.text = "¡Obtuviste un nuevo Item!";
        //Invoke(nameof(DesactivarTexto), 3f);

        //textos.SetActive(true);

        inventory.AddItem(currentItem.GetItem());
        currentItem.DestroySelf();
        currentItem = null;
    }
    void DesactivarTexto()
    {
        textos.SetActive(false); 
    }
}


