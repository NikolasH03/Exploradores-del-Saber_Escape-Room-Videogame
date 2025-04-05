using UnityEngine;

public class HabitatCorrecto : MonoBehaviour
{
    private Vector3 posicionInicial;
    public bool habitatCorrecto;

    void Start()
    {
        posicionInicial = transform.position;
        habitatCorrecto =false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != gameObject.tag)
        {
            transform.position = posicionInicial;

        }
        else if(other.gameObject.tag == gameObject.tag)
        {
            habitatCorrecto=true;
        }
    }
}

