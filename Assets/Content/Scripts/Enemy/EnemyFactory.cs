using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T[] _prefab;
    [SerializeField] private Transform _spawnPoint;

    public T GetNewEnemy()
    {
        Vector3 pos = _spawnPoint.position;

        return Instantiate(_prefab[Random.Range(0, _prefab.Length)], pos, Quaternion.identity);
    }
}
