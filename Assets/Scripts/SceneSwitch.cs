using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    public int sceneTarget = 1;

    void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene(sceneTarget);
    }
}
