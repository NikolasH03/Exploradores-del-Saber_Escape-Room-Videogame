using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonB : MonoBehaviour
{
    public Animator anim;
    public int id;
    public GameController controller;

    private void Start()
    {
        //id = transform.GetSiblingIndex(); // Forzar asignaci�n del ID seg�n el orden en la jerarqu�a
        if (controller == null)
        {
            Debug.LogError("GameController no asignado a " + gameObject.name);
        }
    }

    private void OnMouseDown()
    {
        if (!controller.simonIsSaying)
        {
            Action();
            controller.PlayerAction(this);
        }
    }

    public void Action()
    {
        anim.enabled = true;
        anim.SetTrigger("pop");
    }
}
