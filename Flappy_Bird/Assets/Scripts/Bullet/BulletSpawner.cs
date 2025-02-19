using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Vector3 _spawnOffset;

    private ObjectPool<Bullet> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(_prefab);
    }

    public void RemoveObject(Bullet bullet)
    {
        _pool.PutObject(bullet);
    }

    public void Reset()
    {
        _pool.Reset();
    }

    public void SpawnObject(Vector3 position)
    {
        Bullet bullet = _pool.GetObject();

        bullet.gameObject.SetActive(true);
        bullet.transform.position = position + _spawnOffset;
        bullet.SetSpeed(_bulletSpeed);
    }
}
