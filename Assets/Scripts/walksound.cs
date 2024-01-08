using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walksound : MonoBehaviour
{
    public AudioSource walkeffect;
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walkeffect.enabled = true;
        }
        else
        {
            walkeffect.enabled = false;
        }
    }
}
