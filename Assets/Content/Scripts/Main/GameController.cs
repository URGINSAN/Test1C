using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    public static GameController instance = null;
    [Space]
    [SerializeField] private TankFactory _tankFactory;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Restart()
    {

    }

    public void TestCreateTankEnemy()
    {
        var prefab = _tankFactory.GetNewEnemy();
    }
}
