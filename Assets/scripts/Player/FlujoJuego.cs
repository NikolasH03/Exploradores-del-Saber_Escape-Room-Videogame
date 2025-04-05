using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FlujoJuego : MonoBehaviour
{
    public GameObject textos;
    public bool jugarLaberinto;
    public bool preparadoCicloRana;
    public bool jugarCicloRana;
    public bool preparadoSimon;
    public bool jugarSimon;

    public Player player;

    void Start()
    {
        textos.SetActive(false);
        jugarLaberinto = false;
        preparadoCicloRana = false;
        jugarCicloRana = false;
        preparadoSimon = false;
        jugarSimon = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        TextMeshProUGUI textMesh = textos.GetComponent<TextMeshProUGUI>();

        if (collider.gameObject.tag == "Laberinto" && !GameManager.Instance.terminoLaberinto)
        {
            textos.SetActive(true);
            textMesh.text = "Presiona 'E' para investigar";
            jugarLaberinto = true;
        }

        if (collider.gameObject.tag == "CicloRana" && !GameManager.Instance.terminoCicloRana)
        {
            if (preparadoCicloRana)
            {
                textos.SetActive(true);
                textMesh.text = "Presiona 'E' para investigar";
                jugarCicloRana = true;
            }
            else
            {
                textos.SetActive(true);
                textMesh.text = "Necesitas una llave para acceder a esto";
            }
        }
        if (collider.gameObject.tag == "Simon" && !GameManager.Instance.terminoSimon)
        {
            if (preparadoSimon)
            {
                textos.SetActive(true);
                textMesh.text = "Presiona 'E' para investigar";
                jugarSimon = true;
            }
            else
            {
                textos.SetActive(true);
                textMesh.text = "Necesitas un fusible para encender esto";
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        textos.SetActive(false);
        jugarLaberinto = false;
        jugarCicloRana = false;
        jugarSimon = false;
    }

    void Update()
    {
        if (jugarLaberinto && Input.GetKeyDown(KeyCode.E))
        {
            GuardarPosicionJugador();
            entrarEscena("Laberinto");
        }
        if (jugarCicloRana && Input.GetKeyDown(KeyCode.E))
        {
            GuardarPosicionJugador();
            entrarEscena("CicloRana");
        }
        if (jugarSimon && Input.GetKeyDown(KeyCode.E))
        {
            GuardarPosicionJugador();
            entrarEscena("Simon");
        }

        if (GameManager.Instance.terminoLaberinto)
        {
            player.nuevoItem(1);
            GameManager.Instance.terminoLaberinto = false;
        }

        if (GameManager.Instance.terminoCicloRana)
        {
            player.nuevoItem(2);
            GameManager.Instance.terminoCicloRana = false;
        }
        if (GameManager.Instance.terminoSimon)
        {
            player.nuevoItem(3);
            GameManager.Instance.terminoSimon = false;
        }
    }

    public void GuardarPosicionJugador()
    {
        //if (GameManager.Instance != null && player != null)
        //{
        //    GameManager.Instance.playerPosition = player.transform.position;
        //}
    }

    public void entrarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}

