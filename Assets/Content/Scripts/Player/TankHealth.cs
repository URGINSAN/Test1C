using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public enum Type
    {
        Player = 0,
        Enemy = 1
    }
    public Type type;

    public int Health;

    private void Start()
    {
        if (type == Type.Player)
            Health = GameSettings.instance.PlayerHealth;
        if (type == Type.Enemy)
            Health = GameSettings.instance.EnemyHealth;
    }

    public void Damage()
    {
        if (type == Type.Player)
        {
            Health -= Health = GameSettings.instance.PlayerDamage;
            UIController.instance.SetPlayerHealth(Health);
            GameController.instance.OnPlayerDamage();
        }
        if (type == Type.Enemy)
        {
            Health -= Health = GameSettings.instance.PlayerShootDamage;
        }

        if (Health <= 0)
            OnDeath();
    }

    void OnDeath()
    {
        if (type == Type.Player)
        {
            
        }
        if (type == Type.Enemy)
        {

        }
        Destroy(gameObject);
    }
}
