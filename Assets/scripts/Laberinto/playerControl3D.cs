using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl3D : MonoBehaviour
{
    public float movSpeed; // Velocidad de movimiento
    private Vector3 velocity; // Vector de movimiento
    private Rigidbody rb; // Referencia al Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Leer input en los ejes Horizontal y Vertical
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Crear un vector de movimiento en el plano XZ
        velocity = new Vector3(horizontal, 0, vertical);
        velocity.Normalize(); // Normalizar para mantener la velocidad constante
    }

    void FixedUpdate()
    {
        // Aplicar movimiento al Rigidbody solo en XZ
        rb.velocity = velocity * movSpeed + new Vector3(0, rb.velocity.y, 0);
    }
}

