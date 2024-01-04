using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    public enum Scenes {
        MENU = 0,
        GAME_OUTSIDE = 1,
        GAME_INSIDE = 2
    };


    public const int MENU_SCENE = 0;
    public const int GAME_OUTSIDE_SCENE = 1;
    public const int GAME_INSIDE_SCENE = 2;

    public Scenes sceneTarget;

    void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene((int) sceneTarget);
    }
}
