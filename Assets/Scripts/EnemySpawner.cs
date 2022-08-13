using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _timer;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_timer);

        for (int i = 0; i < _enemyCount; i++)
        {
            int index = Random.Range(0, transform.childCount);
            Instantiate(_enemy, _points[index].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
