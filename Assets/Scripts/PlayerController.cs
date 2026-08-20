using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float xSensitivity = 10.0f;
    public float playerHealth = 100f;

    private bool gameOver = false;
    private InputSystem_Actions.PlayerActions controls;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controls = new InputSystem_Actions().Player;
        
    }

    private void OnEnable()
    {
        controls.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
   {
        controls.Disable();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Update is called once per frame
    void Update()
    {   //We first need to enter the Inputsystem_action then navigate through to the movement options and extract the vector that is made by movement, then we take these values and translate by them.
        Vector2 moveInput = controls.Move.ReadValue<Vector2>();
        float forwardMove = moveInput.y;
        float rightMove = moveInput.x;
        transform.Translate(new Vector3(rightMove, 0, forwardMove)* Time.deltaTime * speed);

        //we do the same for the rotation, note yaw is short hand for rotation around y axis, so looking left and right
        Vector2 rotation = controls.Look.ReadValue<Vector2>();
        float yawInput = rotation.x;
        transform.Rotate(0, yawInput * Time.deltaTime*xSensitivity, 0);

        if (playerHealth <=0 || transform.position.y < -1)
        {
            if (gameOver == false)
            {
                Debug.Log("Game Over");
                Cursor.lockState = CursorLockMode.None;
                gameOver = true;
                playerHealth = 0;
            }
        }
    }
    

}
