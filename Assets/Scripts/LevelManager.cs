using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public static event Action UpdateCoinsEvent;
    public static event Action UpdateKeyEvent;

    [SerializeField] private HUDController _HUDController;
    [SerializeField] private GameOverController _gameOverController;
    [SerializeField] private WinScreenController _winScreenController;

    private int coins;
    private bool keyCollected;

    private void Awake()
    {
        instance = this;
        coins = 0;
        keyCollected = false;
    }

    public void CoinCollected()
    {
        coins++;
        UpdateCoinsEvent.Invoke();
    }

    public void KeyCollected()
    {
        keyCollected = true;
        UpdateKeyEvent.Invoke();
    }

    public int GetCoins()
    {
        return coins;
    }

    public bool IsKeyCollected()
    {
        return keyCollected;
    }

    public void ShowGameOverScreen()
    {
        _HUDController.Hide();
        _gameOverController.Show();
    }

    public void ShowWinScreen()
    {
        _HUDController.Hide();
        _winScreenController.Show();
    }
}
