using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public Enemy Create()
    {
        return Instantiate(_enemyPrefab);
    }
}