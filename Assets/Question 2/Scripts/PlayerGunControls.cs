using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGunControls : MonoBehaviour
{
    public Camera PlayerCamera;
    public float RotationSpeed = 200f;
    float _CameraVerticalAngle = 0f;
    Vector2 _lookInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }


    //Controls player movement with mouse
    void PlayerMovement()
    {
        Vector2 look = _lookInput * RotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0f, look.x, 0f), Space.Self);
        _CameraVerticalAngle -= look.y;
        _CameraVerticalAngle = Mathf.Clamp(_CameraVerticalAngle, -89f, 89f);
        PlayerCamera.transform.localEulerAngles = new Vector3(_CameraVerticalAngle, 0, 0);
    }
}
