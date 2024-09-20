using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private string _gameOverMessage;

    [Header("Links")]
    [SerializeField] private Mover _mover;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private List<Coin> _coinsArray;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _timeCounterText;
    [SerializeField] private TextMeshProUGUI _scoreText; 
    [SerializeField] private TextMeshProUGUI _gameResultText;
    [SerializeField] private GameOverPanel _gameOverPanel;

    [Header("Configs")]
    [SerializeField] private float _timeToWin;

    [SerializeField] private float _primerGitForDel1;    

    private int _collectedCoins;
    private int _numberCoinsInGame;
    private float _currentTimeCounter;

    private Vector3 _playerPositionStart;

    private Player _player;

    private bool _isPlaying;

    private void Awake()
    {
        _player = _mover.GetComponent<Player>();
        _numberCoinsInGame = _coinsArray.Count;
        _playerPositionStart = _player.transform.position;
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (_isPlaying == false && _inputHandler.IsPressKeyRestart)
            StartGame();

        if (_isPlaying == false)
            return;
        GetPlayerCoins();

        _currentTimeCounter -= Time.deltaTime;

        ShowUI();

        if (_currentTimeCounter < 0)
        {
            if (_collectedCoins == _numberCoinsInGame)
                WinGame();
            else
                LoseGame();
        }

        if(_collectedCoins == _numberCoinsInGame)
            WinGame();

    }

    private void WinGame()
    {
        _gameOverMessage = " Ура вы выиграли!!!";

        GameOver(_gameOverMessage);
    }

    private void LoseGame()
    {
        _gameOverMessage = " Вы проиграли!";

        GameOver(_gameOverMessage);
    }

    private void StartGame()
    {
        _player.SetCoinsValueZero();

        _mover.SetWakeUp();
        _mover.MoveStartPosition(_playerPositionStart);
        _mover.SetMovingTrue();

        SetActiveCoins();
        _currentTimeCounter = _timeToWin;
        _gameOverPanel.Hide();

        _isPlaying = true;
        Debug.Log($"Старт новой игры!");
    }

    private void GameOver(string message)
    {
        _isPlaying = false;
        
        _mover.SetSleeping();
        _mover.SetMovingFalse();

        _gameOverPanel.Swow();
        _gameResultText.text = message;
        Debug.Log($"{message}");
    }

    private void SetActiveCoins()
    {
        if (_coinsArray.Count > 0)
        {
            foreach (Coin coin in _coinsArray)
                coin.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError($" Attention Array{_coinsArray.Count} empty");
        }
    }

    private void GetPlayerCoins()
    {
        _collectedCoins = _player.Coins;
    }

    private void ShowUI()
    {
        _timeCounterText.text = " Time = " + Mathf.Round(_currentTimeCounter).ToString() + " sec";
        _scoreText.text = " Coins = " + _collectedCoins.ToString();
    }
}
