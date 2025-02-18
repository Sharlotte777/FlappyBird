using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _xOffset;

    void Update()
    {
        var position = transform.position;
        position.x = _bird.transform.position.x + _xOffset;
        transform.position = position;
    }
}
