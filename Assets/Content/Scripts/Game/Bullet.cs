using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float destroyTime = 5;
    [SerializeField] GameObject Explosion;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletSpeed = GameSettings.instance.PlayerBulletSpeed;

        Destroy(gameObject, destroyTime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    void OnDestroy()
    {
        GameController.instance.ShakeScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            collision.GetComponent<TankHealth>().Damage();
            Destroy(gameObject);
        }
    }
}
