using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles the rules of the game

public class GameManager : MonoBehaviour
{
    public GameObject[] platforms;

    public GameObject menu;
    public GameObject game;
    public GameObject pause;
    public GameObject gameOver;
    public bool isGameOver = false;
    public bool isPaused = false;
    public int score;


    // State machine needed in our game
    public enum GameState { DEFAULT, MENU, GAMEPLAY, GAMEOVER }

    public GameState gameState = GameState.DEFAULT;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        menu.SetActive(true);
        game.SetActive(false);
        pause.SetActive(false);
        gameOver.SetActive(false);

        // menu.SetActive(false);
        // game.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Switch to tell the game what to do when it is in each of the states
        switch (gameState)
        {
            case GameState.DEFAULT:
                //Debug.Log("default");
                break;

            case GameState.MENU:
                //Debug.Log("menu");
                break; 

            case GameState.GAMEPLAY:
                //Debug.Log("gameplay");
                break;

            case GameState.GAMEOVER:
                //Debug.Log("gameover");
                break;
        }
    }

    public void StartGame()
        {
            menu.SetActive(false);
            game.SetActive(true);
            pause.SetActive(false);
            gameOver.SetActive(false);
        }

    public void GameOver()
    {
        gameOver.SetActive(true);
        isGameOver = true;
    }

    public void RestartGame()
    {
        menu.SetActive(false);
        game.SetActive(true);
        pause.SetActive(false);
        gameOver.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            pause.SetActive(true);
        }
    }

    public void UnpauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pause.SetActive(false);
        }
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }
}
