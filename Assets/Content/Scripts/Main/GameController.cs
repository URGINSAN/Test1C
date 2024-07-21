using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController ui;
    public static GameController instance = null;
    [SerializeField] private TankFactory _tankFactory;
    [SerializeField] private CameraShake Shake;
    public bool ShowStartScreen;
    [Header("GAME PROCESS")]
    public bool GameStarted;
    public GameObject PlayerTank;
    private TankHealth playerTankHealth;
    public int DestroyedEnemy;
    public int NeedToDestroy;

    public Action OnCreateEnemyTank;
    public Action OnGameWin;

    private void Start()
    {
        Application.targetFrameRate = -1;

        if (instance == null)
        {
            instance = this;
        }

        if (ShowStartScreen)
        {
            ui.OpenWindow("Start");
        }
        else
        {
            StartGame();
        }

        NeedToDestroy = GameSettings.instance.EnemyCountForWinTotal;
    }

    public void StartGame()
    {
        GameStarted = true;
        ui.OpenWindow("Game");

        PlayerTank = _tankFactory.GetPlayer().gameObject;
        playerTankHealth = PlayerTank.GetComponent<TankHealth>();

        StartCoroutine(GameProcessIE());
    }

    IEnumerator GameProcessIE()
    {
        yield return new WaitForEndOfFrame();
        _tankFactory.GetNewEnemy();
        OnCreateEnemyTank?.Invoke();
        yield return new WaitForSeconds(GameSettings.instance.CreateTimeOutDelay());

        if (GameStarted)
            StartCoroutine(GameProcessIE());
    }

    public void EnemyTankDestinated()
    {
        ShakeScreen();
        playerTankHealth.Damage();
    }

    public void ShakeScreen()
    {
        Shake.shakeDuration = 0.3f;
    }

    public void OnPlayerDamage()
    {
        if (playerTankHealth.Health <= 0)
        {
            Shake.shakeDuration = 0.3f;
            OnLose();
        }
    }

    public void OnDestroyEnemyTank()
    {
        DestroyedEnemy++;

        if (DestroyedEnemy >= GameSettings.instance.EnemyCountForWinTotal)
            OnWin();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnWin()
    {
        GameStarted = false;

        OnGameWin?.Invoke();
        ui.OpenWindow("Win");
    }

    public void OnLose()
    {
        GameStarted = false;

        ui.OpenWindow("Lose");
    }
}
