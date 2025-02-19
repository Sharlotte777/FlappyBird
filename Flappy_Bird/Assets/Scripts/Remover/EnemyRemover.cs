using UnityEngine;

public class EnemyRemover : MonoBehaviour
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
