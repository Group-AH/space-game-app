using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager {

    /* ==== Singleton pattern ==================================================================== */
    private static readonly Lazy<GameManager> lazy = new Lazy<GameManager>(() => new GameManager());
    private GameManager() {
    }
    
    public static GameManager Instance
    {
        get {
            return lazy.Value;
        }
    }

    /* ==== Variables ============================================================================ */

    /* - for game status ------------------------------------------ */
    private bool gameOver = false;
    public string gameOverMessage;

    public bool isGameOver() {
        return gameOver;
    }

    public void setWin() {
        gameOver = true;
        gameOverMessage = "Congratulations! You've repaired the ship!";
    }

    /* - for player ------------------------------------------------- */
    private float playerHealth = 100.0f;
    private float playerO2Level = 1000.0f;
    public List<string> playerInventory = new List<string>();
    public Vector3 playerPosition = new Vector3(500, 20, 500);

    public float getPlayerHealth() {
        return playerHealth;
    }

    public float getPlayerO2Level() {
        return playerO2Level;
    }

    public void takePlayerHealth(float value) {
        playerHealth -= value;
        if (playerHealth <= 0)
        {
            gameOver = true;
            gameOverMessage = "You died! Better Luck Next Time!";
        }
    }

    public void decrementO2Level() {
        playerO2Level--;
        if (playerO2Level <= 0)
        {
            gameOver = true;
            gameOverMessage = "You Ran Out of Oxygen! Better Luck Next Time!";
        }       
    }

    public void addItemToInventory(string item) {
        playerInventory.Add(item);
    }



    public void resetGame() {
        playerHealth = 100.0f;
        playerO2Level = 1000.0f;
        playerInventory = new List<string>();
        playerPosition = new Vector3(500, 20, 500);
        gameOver = false;
    }
}