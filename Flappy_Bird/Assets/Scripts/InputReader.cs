using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode _jumpKey = KeyCode.Space;
    private const int AttackKey = 1;

    private bool _isAttacking;

    public bool IsAttacking => _isAttacking;

    public event Action AbilityOfJumpChanged;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            AbilityOfJumpChanged?.Invoke();
        }
        else if (Input.GetMouseButtonDown(AttackKey))
        {
            _isAttacking = true;
        }
        else
        {
            _isAttacking = false;
        }
    }
}
