using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenComputerTrigger : MonoBehaviour
{
    public Camera _mainPlayerCamera;
    public Camera _taskCamera;
    
    public MeshRenderer hintMesh;
    public MeshRenderer promptMesh;

    public bool checkForRepairPress = false;
    
    void Update() {
        if (checkForRepairPress) {
            if (Input.GetKeyDown("r")) { 
                if (GameManager.Instance.playerInventory.Contains("missing_piece")) {

                    Time.timeScale = 0; 
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    _mainPlayerCamera.enabled = false;
                    _taskCamera.enabled = true;

                } else {
                    promptMesh.enabled = false;
                    hintMesh.enabled = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            
            promptMesh.enabled = true;
            checkForRepairPress = true;
        }

    }

    void OnTriggerExit(Collider other) { 
        promptMesh.enabled = false;
        hintMesh.enabled = false;
    }
}
