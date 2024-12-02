using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(EnemyFactory))]
public class Spawner : MonoBehaviour
{
    private float _waitTime = 2f;
    private WaitForSeconds _wait;
    private EnemyFactory _enemyFactory;

    private void Awake()
    {
        _enemyFactory = GetComponent<EnemyFactory>();
        _wait = new WaitForSeconds(_waitTime);
        StartCoroutine(CreateEnemyWithWait());
    }

    private IEnumerator CreateEnemyWithWait()
    {
        while (true)
        {
            Enemy enemy = _enemyFactory.Create();
            enemy.transform.position = transform.position;
            enemy.Move(transform.GetChild(Random.Range(0, transform.childCount)).position);
            yield return _wait;
        }
    }
}