using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour
{
    private float _speed;

    private void Update()
    {
        Move();
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Move()
    {
        transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}
