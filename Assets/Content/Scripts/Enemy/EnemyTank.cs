using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;
    [SerializeField] GameObject AppearPart;
    [SerializeField] GameObject FinishPart;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveSpeed = Random.Range(GameSettings.instance.enemyMoveSpeed.Min, GameSettings.instance.enemyMoveSpeed.Max);
        GameController.instance.OnGameWin += OnGameWin;

        Instantiate(AppearPart, transform.position, Quaternion.identity);
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
            Instantiate(FinishPart, transform.position, Quaternion.identity);

            GameController.instance.EnemyTankDestinated();
            Destroy(gameObject);
        }
    }

    void OnGameWin()
    {
        
    }
}
