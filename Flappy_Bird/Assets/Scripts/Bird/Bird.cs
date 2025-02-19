using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
[RequireComponent(typeof(BirdAttacker))]
[RequireComponent(typeof(ScoreCounter))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private BirdCollisionHandler _handler;
    private BirdAttacker _attack;
    private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _handler = GetComponent<BirdCollisionHandler>();
        _attack = GetComponent<BirdAttacker>();
        _scoreCounter = GetComponent<ScoreCounter>();
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
        _scoreCounter.Reset();
    }

    private void ProcessCollision()
    {
        GameOver?.Invoke();
    }
}
