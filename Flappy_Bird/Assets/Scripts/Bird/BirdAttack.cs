using UnityEngine;

[RequireComponent(typeof(BulletSpawner))]
public class BirdAttack : MonoBehaviour
{
    private const int AttackKey = 1;

    [SerializeField] private bool _isActive;

    private BulletSpawner _bulletSpawner;

    private void Start()
    {
        _bulletSpawner = GetComponent<BulletSpawner>();
    }

    private void Update()
    {
        if (_isActive)
        {
            Shoot();
        }
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void Deactivate()
    {
        _isActive = false;
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(AttackKey))
        {
            _bulletSpawner.SpawnObject(transform.position);
        }
    }
}
