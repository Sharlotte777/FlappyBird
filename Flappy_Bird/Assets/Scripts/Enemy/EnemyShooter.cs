using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;

    public void StartShoot(BulletSpawner _bulletSpawner)
    {
        StartCoroutine(GenerateBullets(_bulletSpawner));
    }

    private IEnumerator GenerateBullets(BulletSpawner _bulletSpawner)
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            _bulletSpawner.SpawnObject(transform.position);
            yield return wait;
        }
    }
}
