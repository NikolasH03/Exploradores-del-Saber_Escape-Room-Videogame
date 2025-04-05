using UnityEngine;

public class movimiento : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float normalSpeed;
    [SerializeField] float speed_multiplier;
    [SerializeField] float sensitivity;
    [SerializeField] CharacterController character;
    [SerializeField] GameObject cam;
    [SerializeField] float moveFB, moveLR;
    [SerializeField] float rotX, rotY;
    [SerializeField] Vector2 MaxVerticalRotation;
    [SerializeField] float gravity = -9.8f;

    void Start()
    {
        character = GetComponent<CharacterController>();
        normalSpeed = speed;
    }

    void Update()
    {
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotY = Mathf.Clamp(rotY, MaxVerticalRotation.x, MaxVerticalRotation.y);

        // Movimiento relativo a la rotación del personaje
        Vector3 movement = transform.right * moveLR + transform.forward * moveFB;
        movement.y = gravity; // Agrega la gravedad al movimiento

        CameraRotation(cam, rotX, rotY);
        runCheck();

        character.Move(movement * Time.deltaTime);
    }

    public void runCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * speed_multiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
        }
    }

    void CameraRotation(GameObject cam, float rotX, float rotY)
    {
        transform.Rotate(0, rotX * Time.deltaTime, 0); // Rotación en el eje Y (horizontal) del personaje
        cam.transform.localRotation = Quaternion.Euler(new Vector3(-rotY, 0, 0)); // Rotación en el eje X (vertical) de la cámara
    }
}
