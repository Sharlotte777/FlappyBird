using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(_prefab);
    }

    private void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    public void RemoveObject(Enemy enemy)
    {
        enemy.OnDeath -= HandleEnemyDeath;
        _pool.PutObject(enemy);
    }

    public void Reset()
    {
        _pool.Reset();
    }

    private void HandleEnemyDeath(Enemy enemy)
    {
        _scoreCounter.Add();
        RemoveObject(enemy);
    }

    private IEnumerator GenerateEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy enemy = _pool.GetObject();
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
        enemy.StartShoot(_bulletSpawner);
        enemy.OnDeath += HandleEnemyDeath;
    }
}
