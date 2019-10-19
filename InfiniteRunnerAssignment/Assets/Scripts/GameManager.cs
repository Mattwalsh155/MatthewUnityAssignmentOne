using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private bool isGame = false;
    private bool hasSpawned = false;
    public float score = 0;
    public Text currentScore;
    public Text finalScore;

    public GameObject enemy;
    public GameObject pickup;

    public int randNumber;
    private int xPosEnemy = 4;
    private int yPosEnemy = -3;
    private int xPosPickup = 4;
    private int yPosPickup = -2;


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

        currentScore.text = "Score: " + score.ToString();

            
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(isGame);
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

        if (isGameOver)
        {
            GameOver();
        }

        UpdateScore();

        if (isGame == true)
            {
                if (!hasSpawned)
                {
                    hasSpawned = true;
                    randNumber = Random.Range(2,5);
                    Invoke("SpawnEnemy",randNumber);
                
                    randNumber = Random.Range(5,10);
                    Invoke("SpawnPickup",randNumber);
                }
            }
    }

    public void StartGame()
        {
            menu.SetActive(false);
            game.SetActive(true);
            pause.SetActive(false);
            gameOver.SetActive(false);
            isGame = true;
        }

    public void GameOver()
    {
        menu.SetActive(false);
        game.SetActive(false);
        pause.SetActive(false);
        gameOver.SetActive(true);
        //isGameOver = true;
        isGame = false;
        hasSpawned = false;
        finalScore.text = "Final Score: " + score.ToString();
    }

    public void RestartGame()
    {
        menu.SetActive(false);
        game.SetActive(true);
        pause.SetActive(false);
        gameOver.SetActive(false);
        isGame = false;
        hasSpawned = false;
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            isGame = false;
            pause.SetActive(true);
        }
    }

    public void UnpauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            isGame = true;
            pause.SetActive(false);
        }
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }

    public void UpdateScore()
    {
        if (isGame == true)
        {
        score += 1;
        currentScore.text = "Score: " + score.ToString();
        }
    }

    public void SpawnEnemy()
    {
         if (isGame == true)
         {
            GameObject temp = Instantiate(enemy, new Vector2(0,0), enemy.transform.rotation);
            //xPosEnemy -= 1;
            temp.transform.position = new Vector2(xPosEnemy,yPosEnemy);

            randNumber = Random.Range(1,10);
            Invoke("SpawnEnemy",randNumber);
        }
    }

    public void SpawnPickup()
    {
         if (isGame == true)
         {
            GameObject temp = Instantiate(pickup, new Vector2(0,0), pickup.transform.rotation);
            //xPosPickup -= 1;
            temp.transform.position = new Vector2(xPosPickup,yPosPickup);

            randNumber = Random.Range(5,20);
            Invoke("SpawnPickup",randNumber); 
        }
    }
}
