using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanksSpawnFactory<T> : MonoBehaviour where T : Transform
{
    [SerializeField] private T[] _prefabEnemy;
    [SerializeField] private Transform[] _spawnPointEnemy;
    [Space]
    [SerializeField] private T _prefabPlayer;
    [SerializeField] private Transform _spawnPointPlayer;

    public T GetNewEnemy()
    {
        int randPos = Random.Range(0, _spawnPointEnemy.Length);
        Vector3 pos = _spawnPointEnemy[randPos].position;

        return Instantiate(_prefabEnemy[Random.Range(0, _prefabEnemy.Length)], pos, _spawnPointEnemy[randPos].rotation);
    }

    public T GetPlayer()
    {
        Vector3 pos = _spawnPointPlayer.position;

        return Instantiate(_prefabPlayer, pos, Quaternion.identity);
    }
}
