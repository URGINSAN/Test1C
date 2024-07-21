using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public EnemyCountForWin enemyCountForWin;
    public int EnemyCountForWinTotal;
    public EnemyCreateTimeOut enemyCreateTimeOut;
    public EnemyMoveSpeed enemyMoveSpeed;
    public int EnemyHealth = 100;
    [Space]
    public float PlayerKillRadius = 2.0f;
    public float PlayerShootSpeed = 0.5f;
    public int PlayerShootDamage = 25;
    public float PlayerBulletSpeed = 2.5f;
    public int PlayerHealth = 100;
    public int PlayerDamage = 1;

    public static GameSettings instance = null;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        EnemyCountForWinTotal = Random.Range(enemyCountForWin.Min, enemyCountForWin.Max);
        //EnemyCreateTimeOut = Random.Range(1.5f, 2.5f);
    }

    public float CreateTimeOutDelay()
    {
        float delay = Random.Range(enemyCreateTimeOut.Min, enemyCreateTimeOut.Max);
        return delay;
    }

    [System.Serializable]
    public struct EnemyMoveSpeed
    {
        public float Min;
        public float Max;
    }

    [System.Serializable]
    public struct EnemyCountForWin
    {
        public int Min;
        public int Max;
    }

    [System.Serializable]
    public struct EnemyCreateTimeOut
    {
        public float Min;
        public float Max;
    }
}
