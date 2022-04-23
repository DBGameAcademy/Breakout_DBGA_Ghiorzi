using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    [Header("Header Panel")]
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private List<GameObject> lifeIcons = new List<GameObject>();

    [Header("Game's Panels")]
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject startGamePanel;
    [SerializeField]
    private GameObject pauseGamePanel;
    [SerializeField]
    private GameObject winGamePanel;

    [Header("Effects UI")]
    [SerializeField]
    private Image effectIcon;
    [SerializeField]
    private TimerText effectTimerText;

    public void Start()
    {
        HideGameOver();
        HidePauseGame();
        HideWinGame();
        ShowStartGame();
    }

    public void UpdateScoreText(int value)
    {
        scoreText.text = "Score: "+value.ToString();
    }

    public void UpdateLives(int value)
    {
        for (int i=lifeIcons.Count-1; i>=0; i--)
        {
            lifeIcons[i].SetActive(value > i);
        }
    }

    public void UpdateEffectPanel(Sprite sprite, Color color, float timer)
    {
        effectTimerText.Timer = timer;
        effectIcon.sprite = sprite;
        effectIcon.color = color;
    }

    public void ResetEffectPanel()
    {
        effectTimerText.ResetTimer();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowStartGame()
    {
        startGamePanel.SetActive(true);
    }

    public void HideStartGame()
    {
        startGamePanel.SetActive(false);
    }

    public void ShowPauseGame()
    {
        pauseGamePanel.SetActive(true);
    }

    public void HidePauseGame()
    {
        pauseGamePanel.SetActive(false);
    }

    public void ShowWinGame()
    {
        winGamePanel.SetActive(true);
    }

    public void HideWinGame()
    {
        winGamePanel.SetActive(false);
    }
}
