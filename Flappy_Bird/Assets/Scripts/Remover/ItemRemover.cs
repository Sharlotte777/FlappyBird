using UnityEngine;

public class ItemRemover : MonoBehaviour
{
    [SerializeField] private BulletSpawner _spawnerOfBullets;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Bullet bullet)) 
        {
            _spawnerOfBullets.RemoveObject (bullet);
        }
    }
}
