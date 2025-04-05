using UnityEngine;
using TMPro; // Importar el espacio de nombres de TextMeshPro
using UnityEngine.SceneManagement;
public class DoorController : MonoBehaviour
{
    public bool keyNeeded = false;              // Is key needed for the door
    public bool gotKey;                         // Has the player acquired the key
    public int numberKeys = 0;
    public GameObject txtToDisplay;             // Display the information about how to close/open the door

    private bool playerInZone;                  // Check if the player is in the zone
    private bool doorOpened;                    // Check if the door is currently opened or not

    private Animation doorAnim;
    private BoxCollider doorCollider;           // To enable the player to go through the door if the door is opened else block them

    enum DoorState
    {
        Closed,
        Opened,
        Jammed
    }

    DoorState doorState = new DoorState();      // To check the current state of the door

    /// <summary>
    /// Initial State of every variable
    /// </summary>
    private void Start()
    {
        gotKey = false;
        doorOpened = false;                     // Is the door currently opened
        playerInZone = false;                   // Player not in zone
        doorState = DoorState.Closed;           // Starting state is door closed

        txtToDisplay.SetActive(false);

        doorAnim = transform.parent.gameObject.GetComponent<Animation>();
        doorCollider = transform.parent.gameObject.GetComponent<BoxCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        txtToDisplay.SetActive(true);
        playerInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInZone = false;
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        // To Check if the player is in the zone
        if (playerInZone)
        {
            TextMeshProUGUI textMesh = txtToDisplay.GetComponent<TextMeshProUGUI>(); // Obtener el componente TextMeshProUGUI

            if (doorState == DoorState.Opened)
            {
                textMesh.text = "'E' para cerrar";
                doorCollider.enabled = false;
            }
            else if (doorState == DoorState.Closed || gotKey)
            {
                textMesh.text = "'E' para abrir";
                doorCollider.enabled = true;
            }
            else if (doorState == DoorState.Jammed)
            {
                if (numberKeys == 0)
                {
                    textMesh.text = "Necesita tres llaves";
                }
                else if (numberKeys == 1)
                {
                    textMesh.text = "Necesita dos llaves más";
                }
                else if (numberKeys == 2)
                {
                    textMesh.text = "Necesita una llave más";
                }

                doorCollider.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && playerInZone)
        {
            doorOpened = !doorOpened;           // The toggle function of the door to open/close

            if (doorState == DoorState.Closed && !doorAnim.isPlaying)
            {
                if (!keyNeeded)
                {
                    doorAnim.Play("Door_Open");
                    doorState = DoorState.Opened;
                }
                else if (keyNeeded && !gotKey)
                {
                    if (doorAnim.GetClip("Door_Jam") != null)
                        doorAnim.Play("Door_Jam");
                    doorState = DoorState.Jammed;
                }
            }

            if (doorState == DoorState.Closed && gotKey && !doorAnim.isPlaying)
            {
                doorAnim.Play("Door_Open");
                doorState = DoorState.Opened;
                Invoke(nameof(terminar), 3f);
            }

            if (doorState == DoorState.Opened && !doorAnim.isPlaying)
            {
                doorAnim.Play("Door_Close");
                doorState = DoorState.Closed;
            }

            if (doorState == DoorState.Jammed && !gotKey)
            {
                if (doorAnim.GetClip("Door_Jam") != null)
                    doorAnim.Play("Door_Jam");
                doorState = DoorState.Jammed;
            }
            else if (doorState == DoorState.Jammed && gotKey && !doorAnim.isPlaying)
            {
                doorAnim.Play("Door_Open");
                doorState = DoorState.Opened;
                Invoke(nameof(terminar), 3f);
            }
        }
    }
    void terminar()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}

