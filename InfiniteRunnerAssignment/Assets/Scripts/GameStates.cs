using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    // State Machine example. Need this in our game
    public enum GameState { DEFAULT, MENU, GAMEPLAY, GAMEOVER }

    public GameState gameState = GameState.DEFAULT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Switch to tell the game what to do when it is in each of the states
        switch (gameState)
        {
            case GameState.DEFAULT:
                Debug.Log("default");
                break;

            case GameState.MENU:
                Debug.Log("menu");
                break;

            case GameState.GAMEPLAY:
                Debug.Log("gameplay");
                break;

            case GameState.GAMEOVER:
                Debug.Log("gameover");
                break;
        }
    }
}
