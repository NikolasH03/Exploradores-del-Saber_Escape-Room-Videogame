using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject keyboardImage;

    private void Start()
    {
        keyboardImage.SetActive(false);
    }
    public void Comenzar(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }
    public void keyboard()
    {
        keyboardImage.SetActive(true);
    }
    public void volver()
    {
        keyboardImage.SetActive(false);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
