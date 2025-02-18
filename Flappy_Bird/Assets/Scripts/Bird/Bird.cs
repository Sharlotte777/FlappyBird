using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
[RequireComponent(typeof(BirdAttack))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private BirdCollisionHandler _handler;
    private BirdAttack _attack;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _handler = GetComponent<BirdCollisionHandler>();
        _attack = GetComponent<BirdAttack>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameOver?.Invoke();
    }

    public void Reset()
    {
        _birdMover.Reset();
    }

    private void ProcessCollision()
    {
        GameOver?.Invoke();
    }
}
