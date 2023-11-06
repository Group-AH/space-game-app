using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class ButtonActions : MonoBehaviour
{
    public void exitGame() {  
        Application.Quit();  
    }

    public void playGame() {  
        SceneManager.LoadScene(SceneSwitch.GAME_OUTSIDE_SCENE);
    }


}
