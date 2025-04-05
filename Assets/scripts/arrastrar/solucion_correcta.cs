using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class solucion_correcta : MonoBehaviour
{
    public int contador=0;
    [SerializeField] GameObject boton;
    void Start()
    {
        boton.SetActive(false);
    }
    private void Update()
    {
        if(contador == 6) {
            boton.SetActive(true);
        
        }
    }

    public void volverJuego(string escena)
    {
        GameManager.Instance.terminoCicloRana = true;
        SceneManager.LoadScene(escena);
    }


}
