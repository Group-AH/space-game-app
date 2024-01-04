using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator target;
    void OnTriggerEnter(Collider other) {

        target.SetBool("character_nearby", true);
    }

    void OnTriggerExit(Collider other) {

        target.SetBool("character_nearby", false);
    }
}
