using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerAnimales : MonoBehaviour
{
    [SerializeField] HabitatCorrecto[] habitats; 
    [SerializeField] GameObject[] playerArray;
    [SerializeField] GameObject boton;
    private int currentPlayerIndex = 0; 

    void Start()
    {
        boton.SetActive(false);

        for (int i = 0; i < playerArray.Length; i++)
        {
            if (i == currentPlayerIndex)
            {
                playerArray[i].SetActive(true); 
                playerArray[i].GetComponent<playerControl3D>().enabled = true; 
            }
            else
            {
                playerArray[i].SetActive(false); 
                playerArray[i].GetComponent<playerControl3D>().enabled = false; 
            }
        }
    }

    void Update()
    {

        for (int i = 0; i < habitats.Length; i++)
        {
            if (habitats[i] != null && habitats[i].habitatCorrecto && i == currentPlayerIndex)
            {
                SwitchPlayer();
                break; 
            }
        }

        if (AllPlayersInactive())
        {
            boton.SetActive(true);

        }
    }


    private void SwitchPlayer()
    {

        playerArray[currentPlayerIndex].GetComponent<playerControl3D>().enabled = false;

        currentPlayerIndex++;

        if (currentPlayerIndex < playerArray.Length)
        {
            playerArray[currentPlayerIndex].SetActive(true);
            playerArray[currentPlayerIndex].GetComponent<playerControl3D>().enabled = true;
        }
    }
    private bool AllPlayersInactive()
    {
        foreach (var player in playerArray)
        {
            playerControl3D movementScript = player.GetComponent<playerControl3D>();

            if (movementScript != null && movementScript.enabled)
            {
                return false; 
            }
        }
        return true; 
    }

    public void volverJuego(string escena)
    {
        GameManager.Instance.terminoLaberinto = true;
        SceneManager.LoadScene(escena);
    }
}


