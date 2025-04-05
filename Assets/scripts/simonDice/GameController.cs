using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public ButtonB[] btns;

    public int simonMax;
    public float simonTime;

    public List<int> userList, simonList;

    public bool simonIsSaying;

    // Sonidos
    [SerializeField] AudioSource sfxSource;
    public AudioClip gallo;
    public AudioClip aguila;
    public AudioClip pato;

    public int rondasCorrectas;
    public GameObject txtToDisplay;

    public GameObject boton;

    void Start()
    {
        boton.SetActive(false);
        rondasCorrectas = 0;

        simonMax = 3;
        simonTime = 1.5f;

        userList = new List<int>();
        simonList = new List<int>();

        // Inicializar texto
        if (txtToDisplay.TryGetComponent(out TextMeshProUGUI textMesh))
        {
            textMesh.text = "rondas correctas: 0";
        }

        StartCoroutine(SimonSays());
    }

    public void PlayerAction(ButtonB b)
    {
        TextMeshProUGUI textMesh = txtToDisplay.GetComponent<TextMeshProUGUI>();
        userList.Add(b.id);

        // Comparamos el último elemento de las listas
        int currentIndex = userList.Count - 1;
        if (currentIndex < simonList.Count && userList[currentIndex] != simonList[currentIndex])
        {
            // Error del jugador, reiniciamos
            Debug.Log("Error en la secuencia. Reiniciando ronda.");
            rondasCorrectas = 0;
            textMesh.text = "rondas correctas: " + rondasCorrectas;

            simonMax = 3;

            // Limpiar listas
            userList.Clear();
            simonList.Clear();

            StopAllCoroutines();
            StartCoroutine(SimonSays());
            return;
        }

        // Si el jugador completa la secuencia correctamente
        if (userList.Count == simonList.Count)
        {
            rondasCorrectas++;
            textMesh.text = "rondas correctas: " + rondasCorrectas;

            if (rondasCorrectas == 3)
            {
                boton.SetActive(true); // Mostrar botón para continuar
            }
            else
            {
                StartCoroutine(SimonSays()); // Siguiente ronda
            }
        }

        Debug.Log("Usuario ingresó: " + string.Join(",", userList));
    }

    IEnumerator SimonSays()
    {
        yield return new WaitForSeconds(1);
        simonIsSaying = true;

        // Limpiar listas
        userList.Clear();
        simonList.Clear();

        for (int i = 0; i < simonMax; i++)
        {
            int rand = Random.Range(0, btns.Length);
            simonList.Add(rand);
            btns[rand].Action();

            switch (rand)
            {
                case 0:
                    sfxSource.PlayOneShot(aguila); break;
                case 1:
                    sfxSource.PlayOneShot(gallo); break;
                case 2:
                    sfxSource.PlayOneShot(pato); break;
                default: break;
            }

            yield return new WaitForSeconds(simonTime);
        }

        Debug.Log("Nueva secuencia de Simon: " + string.Join(",", simonList));
        simonMax++;
        simonIsSaying = false;
    }

    public void volverJuego(string escena)
    {
        GameManager.Instance.terminoSimon = true;
        SceneManager.LoadScene(escena);
    }
}





