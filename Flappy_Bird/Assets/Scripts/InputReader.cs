using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode _jumpKey = KeyCode.Space;

    public event Action AbilityOfJumpChanged;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            AbilityOfJumpChanged?.Invoke();
        }
    }
}
