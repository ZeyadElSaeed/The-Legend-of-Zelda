using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField] private float mouseSensitevity;
    public enum RotationDirection
    {
        None,
        Horizontal = (1 << 0),
        Vertical = (1 << 1)
    }
    [SerializeField] private RotationDirection rotationDirection;
    [SerializeField] private Vector2 mouseSensitevity;
    [SerializeField] private float maxVertiacalAngleFromHorizon;
    private Vector2 rotation;
    private void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
        //Screen.lockCursor = false;
    }
    private void Update()
    {
        Vector2 wantedVelocity = GetInput() * mouseSensitevity;

        if ((rotationDirection & RotationDirection.Horizontal) == 0)
        {
            wantedVelocity.x = 0;
        }
        if ((rotationDirection & RotationDirection.Vertical) == 0)
        {
            wantedVelocity.y = 0;
        }

        rotation += wantedVelocity * Time.deltaTime;
        rotation.y = clampVerticalAngle(rotation.y);
        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);

    }

    private float clampVerticalAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxVertiacalAngleFromHorizon, maxVertiacalAngleFromHorizon);
    }
    private Vector2 GetInput()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y")
            );

        return input;
    }
    
}