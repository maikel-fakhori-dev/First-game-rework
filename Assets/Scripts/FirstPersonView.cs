using UnityEngine;
using UnityEngine.Rendering;

public class FirstPersonView : MonoBehaviour
{
    public float ySensitivity = 1.0f;


    private InputSystem_Actions.PlayerActions controls;

    private float pitch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controls = new InputSystem_Actions().Player;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    //private void OnDisable()
    //{
    //    controls.Disable();
    //}
   
    // Update is called once per frame
    void Update()
    {
        //
        Vector2 rotation = controls.Look.ReadValue<Vector2>();
        float pitchInput = rotation.y;
        // Add mouse movement to current pitch
        pitch -= pitchInput * Time.deltaTime * ySensitivity;

        // Clamp the accumulated pitch
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Apply rotation
        transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
