using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstronautThirdPersonCamera
{

  public class AstronautThirdPersonCamera : MonoBehaviour
  {
    public float Y_ANGLE_MIN = -10.0f;
    public float Y_ANGLE_MAX = 80.0f;

    public Transform player;
    public Transform playerRoot;

    public float distance = 5.0f;

    private float currentX = 0.0f;
    private float currentY = 10.0f;
    public float mouseSensitivity = 4f;

    private void Start()
    {
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
        Vector3 offset = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        
        transform.position = player.position + rotation * offset;

        transform.LookAt(player.position);

        var lookPos = player.position - transform.position;
        lookPos.y = 0;

        playerRoot.rotation = Quaternion.LookRotation(lookPos);
        
    }
  }
}
