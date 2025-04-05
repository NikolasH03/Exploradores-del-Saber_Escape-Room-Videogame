using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool terminoLaberinto;
    public bool terminoCicloRana;
    public bool terminoSimon;
    //public Vector3 playerPosition;
    private void Awake()
    {
     
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        terminoLaberinto = false;
        terminoCicloRana= false;
        terminoSimon=false;
    }
}

