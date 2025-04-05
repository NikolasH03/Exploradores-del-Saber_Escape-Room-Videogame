using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public bool PausaJ = false;
    public GameObject MenuSalir;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausaJ==false)
            {
                ObjetoMenuPausa.SetActive(true);
                PausaJ = true;
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

                // AudioSource[] Sonidos = FindObjectsOfType<audioSource>();

                //for (int i = 0; i < Sonidos.Length; i++)
                //{
                //  Sonidos[i].Pause();
                //}
            }
            else if (PausaJ == true)
            {
            Resumir();
            }
        }
    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        MenuSalir.SetActive(false);
        PausaJ = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


       // AudioSource[] Sonidos = FindObjectsOfType<audioSource>();

        //for (int i = 0; i < Sonidos.Length; i++)
        //{
          //  Sonidos[i].play();
        //}
    }

    public void IrMenuP(string nombreMenu)
    {
        SceneManager.LoadScene(nombreMenu);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
