using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitevity;

    private Transform parent;
    private void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") *mouseSensitevity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitevity * Time.deltaTime;
        parent.Rotate(Vector3.up , mouseX);
        //parent.Rotate(Vector3.right, mouseY);
    }
}
