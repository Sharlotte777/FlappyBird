using UnityEngine;

[RequireComponent(typeof(BulletSpawner))]
[RequireComponent(typeof(InputReader))]
public class BirdAttacker : MonoBehaviour
{
    private BulletSpawner _bulletSpawner;
    private InputReader _inputReader;

    private void Start()
    {
        _bulletSpawner = GetComponent<BulletSpawner>();
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        if (_inputReader.IsAttacking)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        _bulletSpawner.SpawnObject(transform.position);
    }
}
