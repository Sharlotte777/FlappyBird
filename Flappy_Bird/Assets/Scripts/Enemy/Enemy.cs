using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
[RequireComponent(typeof(EnemyCollisionHandler))]
public class Enemy : MonoBehaviour
{
    private EnemyShooter _shoot;
    private EnemyCollisionHandler _collisionHandler;

    public event Action<Enemy> OnDeath;

    private void Awake()
    {
        _shoot = GetComponent<EnemyShooter>();
        _collisionHandler = GetComponent<EnemyCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void StartShoot(BulletSpawner bulletSpawner)
    {
        _shoot.StartShoot(bulletSpawner);
    }

    private void ProcessCollision(Bullet itemBullet)
    {
        if (itemBullet.TryGetComponent(out Bullet bullet))
        {
            OnDeath?.Invoke(this);
        }
    }
}
