using UnityEngine;

public class RemoverEnemy : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawnerOfEnemies;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _spawnerOfEnemies.RemoveObject(enemy);
        }
    }
}
