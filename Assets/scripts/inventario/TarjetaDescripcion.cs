using System.Collections.Generic;
using UnityEngine;

public class TarjetaDescripcion : MonoBehaviour
{
    [SerializeField] GameObject contenedorTarjetas;
    [SerializeField] List<GameObject> tarjetas;

    private bool ItemDetectadoLlave = false;
    private bool ItemDetectadoHongo = false;
    private bool ItemDetectadofusible = false;
    private bool ItemDetectadollaveFinal = false;
    private int tarjetaActivaIndex = -1; // Índice de la tarjeta activa actualmente
    private int indiceActual = 0;
    [SerializeField] GameObject botonSiguiente;
    [SerializeField] GameObject botonAnterior;
    void Start()
    {
        contenedorTarjetas.SetActive(false);

        for (int i = 0; i < tarjetas.Count; i++)
        {
            if (tarjetas[i] != null)
            {
                tarjetas[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        if (!ItemDetectadoLlave && GameObject.FindWithTag("llave") != null)
        {
            ItemDetectadoLlave = true;

            for (int i = 0; i < tarjetas.Count; i++)
            {
                if (tarjetas[i] != null && tarjetas[i].CompareTag("tarjetaLlave"))
                {
                    tarjetas[i].SetActive(true);
                    tarjetaActivaIndex = i; 
                }
            }
        }
        if (!ItemDetectadoHongo && GameObject.FindWithTag("hongo") != null)
        {
            ItemDetectadoHongo = true;

            for (int i = 0; i < tarjetas.Count; i++)
            {
                if (tarjetas[i] != null && tarjetas[i].CompareTag("tarjetaHongo"))
                {
                    tarjetas[i].SetActive(true);
                    if (tarjetaActivaIndex == -1) 
                    {
                        tarjetaActivaIndex = i;
                    }
                }
            }
        }
        if (!ItemDetectadofusible && GameObject.FindWithTag("fusible") != null)
        {
            ItemDetectadofusible = true;

            for (int i = 0; i < tarjetas.Count; i++)
            {
                if (tarjetas[i] != null && tarjetas[i].CompareTag("tarjetaFusible"))
                {
                    tarjetas[i].SetActive(true);
                    if (tarjetaActivaIndex == -1) 
                    {
                        tarjetaActivaIndex = i;
                    }
                }
            }
        }
        if (!ItemDetectadollaveFinal && GameObject.FindWithTag("llaveFinal") != null)
        {
            ItemDetectadollaveFinal = true;

            for (int i = 0; i < tarjetas.Count; i++)
            {
                if (tarjetas[i] != null && tarjetas[i].CompareTag("tarjetallaveFinal"))
                {
                    tarjetas[i].SetActive(true);
                    if (tarjetaActivaIndex == -1) 
                    {
                        tarjetaActivaIndex = i;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (contenedorTarjetas.activeSelf)
            {
                contenedorTarjetas.SetActive(false);
            }
            else
            {
                contenedorTarjetas.SetActive(true);
            }
        }
    }

    // Cambiar tarjeta visible al avanzar
    public void MostrarSiguienteTarjeta()
    {
        if (tarjetas.Count == 0) return;

        // Mover la tarjeta actual al principio
        tarjetas[indiceActual].transform.SetAsFirstSibling();

        // Incrementar el índice
        indiceActual = (indiceActual + 1) % tarjetas.Count;

        // Mover la nueva tarjeta al final
        tarjetas[indiceActual].transform.SetAsLastSibling();

        // Mantener los botones al fondo de la jerarquía
        MoverBotonesAlFondo();
    }

    // Cambiar tarjeta visible al retroceder
    public void MostrarTarjetaAnterior()
    {
        if (tarjetas.Count == 0) return;

        // Mover la tarjeta actual al principio
        tarjetas[indiceActual].transform.SetAsFirstSibling();

        // Decrementar el índice
        indiceActual = (indiceActual - 1 + tarjetas.Count) % tarjetas.Count;

        // Mover la nueva tarjeta al final
        tarjetas[indiceActual].transform.SetAsLastSibling();

        // Mantener los botones al fondo de la jerarquía
        MoverBotonesAlFondo();
    }

    // Mantener los botones siempre al fondo de la jerarquía
    private void MoverBotonesAlFondo()
    {
        botonSiguiente.transform.SetAsLastSibling();
        botonAnterior.transform.SetAsLastSibling();
    }
}


