using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform modelWrapperTransform;
    Vector3 startingModelWrapperRotationEuler;
    float moveSpeed = 5f;
    float acceleration = 7f;
    float rotateSpeed = 0.03f;
    Vector3 playerMovementInput = Vector3.zero;
    Rigidbody rb;
    Coroutine currentRotateCall;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingModelWrapperRotationEuler = modelWrapperTransform.localEulerAngles;
    }

    public void ResetModelRotation()
    {
        if (currentRotateCall != null)
        {
            StopCoroutine(currentRotateCall);
        }
        modelWrapperTransform.localRotation = Quaternion.Euler(startingModelWrapperRotationEuler);
    }

    public void KillExcessMomentum()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        playerMovementInput = new Vector3(context.ReadValue<Vector2>().x, playerMovementInput.y, context.ReadValue<Vector2>().y);
        StartRotatePlayerModel(playerMovementInput);
    }

    void FixedUpdate()
    {
        rb.AddForce(playerMovementInput * acceleration, ForceMode.VelocityChange);
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, moveSpeed);
    }

    void StartRotatePlayerModel(Vector3 directionToLook)
    {
        if (currentRotateCall != null)
        {
            StopCoroutine(currentRotateCall);
        }
        currentRotateCall = StartCoroutine(RotatePlayerModel(rotateSpeed, directionToLook));
    }

    IEnumerator RotatePlayerModel(float rotateSpeed, Vector3 directionToLook)
    {
        if (Mathf.Approximately(directionToLook.x, 0) && Mathf.Approximately(directionToLook.z, 0))
        {
            //no input but dont set to 90*
            yield break;
        }

        float targetRotationAngle = -Mathf.Atan2(directionToLook.z, directionToLook.x) * (180f / Mathf.PI);
        //Debug.Log(directionToLook.z + " / " + directionToLook.x + " = " + targetRotationAngle);
        while (!Mathf.Approximately(modelWrapperTransform.localEulerAngles.y, targetRotationAngle))
        {
            float newAngle = Mathf.LerpAngle(modelWrapperTransform.localEulerAngles.y, targetRotationAngle, rotateSpeed);
            modelWrapperTransform.localRotation = Quaternion.Euler(new Vector3(modelWrapperTransform.localEulerAngles.x, newAngle, modelWrapperTransform.localEulerAngles.z));
            yield return new WaitForEndOfFrame();
        }
        modelWrapperTransform.localRotation = Quaternion.Euler(modelWrapperTransform.localEulerAngles.x, targetRotationAngle, modelWrapperTransform.localEulerAngles.z);
    }
}
