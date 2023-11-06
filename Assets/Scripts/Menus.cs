using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  


public class Menus : MonoBehaviour
{
    public static bool gamePaused = false;

    public static bool showPauseMenu = false;
    public static bool showGameOverMenu = false;
    
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    void Update() {
        if (showGameOverMenu) return;

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            if (gamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        gamePaused = false;
        showPauseMenu = false;
        showGameOverMenu = false;

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause() {
        gamePaused = true;
        showPauseMenu = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowGameOver() {
        gamePaused = true;
        showGameOverMenu = true;

        gameOverMenu.SetActive(true);
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    
    public void ExitGame() {  
        Application.Quit();  
    }

    public void GoToMainMenu() {
        Resume();
  
        gameOverMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(SceneSwitch.MENU_SCENE);
    }

    public void RestartGame() {
        Resume();
        gameOverMenu.SetActive(false);

        SceneManager.LoadScene(SceneSwitch.GAME_OUTSIDE_SCENE);
    }


}
