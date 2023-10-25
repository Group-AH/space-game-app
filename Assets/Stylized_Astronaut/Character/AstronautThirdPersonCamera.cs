using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstronautThirdPersonCamera
{

  public class AstronautThirdPersonCamera : MonoBehaviour
  {
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 80.0f;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 5.0f;

    private float currentX = 0.0f;
    private float currentY = 45.0f;
    public float mouseSensitivity = 2.5f;
    private float sensitivityX = 20.0f;
    private float sensitivityY = 20.0f;

    private void Start()
    {
        camTransform = transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * mouseSensitivity;
        currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
  }
}
