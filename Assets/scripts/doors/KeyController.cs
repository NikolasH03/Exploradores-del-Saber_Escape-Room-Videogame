using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;


public class KeyController : MonoBehaviour
{
    CapsuleCollider keyCollider;
    Rigidbody keyRB;
    public GameObject txtToDisplay;
    TextMeshProUGUI textMesh;
    public DoorController DC;

    /// <summary>
    /// Incase user forgets to uncheck isTrigger in box collider
    /// This sets them automatically
    /// </summary>
    private void Start()
    {
        textMesh = txtToDisplay.GetComponent<TextMeshProUGUI>();
        keyCollider = GetComponent<CapsuleCollider>();

        keyCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DC.numberKeys++;
            if(DC.numberKeys == 3)
            {
                DC.gotKey = true;
            }
            
            txtToDisplay.gameObject.SetActive(true);
            textMesh.text = "Llave Adquirida";
            this.gameObject.SetActive(false);
        }
    }
}
