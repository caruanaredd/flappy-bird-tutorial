using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// These are the states for this game.
public enum GameState
{
    TitleScreen, Game, GameOverScreen
}

public class GameManager : MonoBehaviour
{
    public static GameManager current { get; private set; }

    public static GameState state { get; private set; } = GameState.TitleScreen;

    private void Awake()
    {
        // check that the instance for GameManager exists,
        // if not, set it to this class.
        if (current == null)
        {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void StartGame()
    {
        // change the game state so we know we're playing.
        state = GameState.Game;

        // enable control for the player.
        FindObjectOfType<FlapControl>().Activate();

        // start the pipe spawning.
        FindObjectOfType<PipeManager>().Spawn();

        // disable the title screen.
        GameObject.Find("GetReady").SetActive(false);
    }

    public void StopGame()
    {
        // change the game state so we know we lost.
        state = GameState.GameOverScreen;

        // disable all the colliders on the pipes.
        FindObjectOfType<PipeManager>().Disable();

        // show the game over UI.
        GameObject.Find("GameOver").SetActive(true);
    }
}
