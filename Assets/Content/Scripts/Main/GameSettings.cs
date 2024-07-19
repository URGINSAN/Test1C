using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private int EnemyCountForWin;
    [SerializeField] private float EnemyCreateTimeOut;
    [SerializeField] private float EnemyMoveSpeed;
    [SerializeField] private int EnemyHealth = 100;
    [Space]
    [SerializeField] private float PlayerKillRadius = 2.0f;
    [SerializeField] private float PlayerShootSpeed = 0.5f;
    [SerializeField] private int PlayerShootDamage = 25;
    [SerializeField] private float PlayerBulletSpeed = 2.5f;

    private void Start()
    {
        EnemyCountForWin = Random.Range(3, 10);
        EnemyCreateTimeOut = Random.Range(1.5f, 2.5f);
        EnemyMoveSpeed = Random.Range(1.5f, 2.5f);
    }
}
