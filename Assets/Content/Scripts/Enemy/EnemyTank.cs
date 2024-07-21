using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveSpeed = Random.Range(GameSettings.instance.enemyMoveSpeed.Min, GameSettings.instance.enemyMoveSpeed.Max);
        GameController.instance.OnGameWin += OnGameWin;
    }

    void FixedUpdate()
    {
        if (GameController.instance.GameStarted)
            rb.velocity = Vector2.down * MoveSpeed;
        if (!GameController.instance.GameStarted)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Finish"))
        {
            GameController.instance.EnemyTankDestinated();
            Destroy(gameObject);
        }
    }

    void OnGameWin()
    {
        
    }

    private void OnDestroy()
    {
        GameController.instance.OnDestroyEnemyTank();
    }
}
