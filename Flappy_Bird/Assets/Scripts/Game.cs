using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletSpawner _enemyBulletSpawner;
    [SerializeField] private BulletSpawner _playerBulletSpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.PlayButtonClicked += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.PlayButtonClicked -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Awake()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _endScreen.Close();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _enemySpawner.Reset();
        _enemyBulletSpawner.Reset();
        _playerBulletSpawner.Reset();
        _endScreen.Open();
    }
}
