using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public static event Action OnGameReset;
    public bool IsPlaying { get; private set; }
    public bool IsPaused { get; private set; }
    public int Score { get; private set; }
    
    [SerializeField]
    private int initialLives = 3;
    [SerializeField]
    private Paddle paddle;
    [SerializeField]
    private ParticleSystem loseLife;

    private int _lives;

    private void Start()
    {
        Score = 0;
        UIController.Instance.UpdateScoreText(0);
        UIController.Instance.UpdateLives(_lives);

        PauseGame();
    }

    private void Update()
    {
        if(BlockController.Instance.BlocksCount == 0 && IsPlaying)
        {
            GameWon();
        }
    }

    public void StartGame()
    {
        IsPlaying = true;
        ResetGame();
        UnpauseGame();
    }

    public void AddScore(int value)
    {
        Score += value;
        UIController.Instance.UpdateScoreText(Score);
    }

    public void BallLost(Ball ball)
    {
        if (MultiballController.Instance.BallCount == 1)
        {
            // Particle
            if (_lives != 0)
            {
                Instantiate(loseLife, new Vector3(ball.transform.position.x, -Camera.main.orthographicSize+1.0f, 0.0f), Quaternion.identity);
            }
            
            LoseLife();
        }
            

        ball.BallReset();
    }

    public void LoseLife()
    {
        _lives--;
        UIController.Instance.UpdateLives(_lives);
        if (_lives < 0)
        {
            Debug.Log("[GameController BallLost]: Game Over");
            GameOver();
        }
    }

    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0;

        if (IsPlaying)
        {
            UIController.Instance.ShowPauseGame();
        }
    }

    public void UnpauseGame()
    {
        IsPaused = false;
        Time.timeScale = 1;

        UIController.Instance.HidePauseGame();
    }

    public void QuitGame()
    {
        IsPlaying = false;
        PauseGame();
        UIController.Instance.HideGameOver();
        UIController.Instance.HidePauseGame();
        UIController.Instance.HideWinGame();
        UIController.Instance.ShowStartGame();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        GameScenesManager.Instance.LoadScene("Menu");
    }

    private void GameWon()
    {
        UIController.Instance.ShowWinGame();
        IsPlaying = false;
        PauseGame();
    }

    private void GameOver()
    {
        UIController.Instance.ShowGameOver();
        IsPlaying = false;
        PauseGame();
    }

    private void ResetGame()
    {
        OnGameReset?.Invoke();

        _lives = initialLives;
        Score = 0;
        UIController.Instance.UpdateScoreText(Score);
        UIController.Instance.UpdateLives(_lives);
        UIController.Instance.HideGameOver();
        UIController.Instance.HideStartGame();
        UIController.Instance.HideWinGame();
        BlockController.Instance.ResetBlocks();

        MultiballController.Instance.ResetGameBall();
        MultiballController.Instance.ResetAllBallVelocity();

        paddle.ResetPosition();

        EffectController.Instance.ResetEffect();
        UIController.Instance.ResetEffectPanel();

        AISpawnController.Instance.DestroyPaddle();
    }

    
}
