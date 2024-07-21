using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    public float ShootDelay;
    public Transform Tower;
    public Transform ShootPos;
    public GameObject Bullet;
    public Transform NearestEnemy;
    [SerializeField] private float towerSpeed = 30;

    private void Start()
    {
        ShootDelay = GameSettings.instance.PlayerShootSpeed;
        StartCoroutine(ShootIE());
    }

    private void Update()
    {
        EnemyTank[] enemies = FindObjectsOfType<EnemyTank>();
        NearestEnemy = GetClosestEnemy(enemies);

        if (NearestEnemy != null)
        {
            float angle = Mathf.Atan2(NearestEnemy.position.y - transform.position.y, NearestEnemy.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
            var targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            Tower.rotation = Quaternion.RotateTowards(Tower.rotation, targetRotation, towerSpeed * Time.deltaTime);
        }
    }

    IEnumerator ShootIE()
    {
        if (NearestEnemy != null && Vector2.Distance(transform.position, NearestEnemy.position) <= GameSettings.instance.PlayerKillRadius)
        {
            GameObject go = Instantiate(Bullet, ShootPos.position, ShootPos.rotation);
        }

        yield return new WaitForSeconds(ShootDelay);
        if (GameController.instance.GameStarted)
            StartCoroutine(ShootIE());
    }

    Transform GetClosestEnemy(EnemyTank[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (EnemyTank t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }
}
