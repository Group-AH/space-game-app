using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstronautThirdPersonCamera
{

  public class AstronautThirdPersonCamera : MonoBehaviour
  {
    public const float Y_ANGLE_MIN = -80.0f;
    public const float Y_ANGLE_MAX = 80.0f;

    public Transform player;
    public Transform playerRoot;

    public float distance = 5.0f;

    private float currentX = 0.0f;
    private float currentY = 10.0f;
    public float mouseSensitivity = 4f;

    public bool firstPerson = false;
    private Vector3 relativePos;
    public float distanceOffset = 0;

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


        if (!firstPerson) {
            relativePos = transform.position - player.position;
            RaycastHit hit;
            if (Physics.Raycast(player.position, relativePos, out hit, distance + 0.5f))
            {
                Debug.DrawLine(player.position, hit.point);
                distanceOffset = distance - hit.distance + 1f;
                distanceOffset = Mathf.Clamp(distanceOffset, 0, distance);
            }
            else
            {
                distanceOffset = 0;
            }
        }
    }

    private void LateUpdate()
    {        
        Vector3 offset = new Vector3(0, 0, -distance + distanceOffset);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        
        transform.position = player.position + rotation * offset;

        transform.LookAt(player.position);

        var lookPos = player.position - transform.position;
        lookPos.y = 0;

        playerRoot.rotation = Quaternion.LookRotation(lookPos);
        
    }
  }
}
