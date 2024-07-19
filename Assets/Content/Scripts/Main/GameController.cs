using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    public static GameController instance = null;

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
}
