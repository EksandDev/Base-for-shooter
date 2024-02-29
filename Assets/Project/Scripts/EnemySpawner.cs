using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private EnemyCreator[] _creators;

    private float _timer;
    private float _delay = 2;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _delay)
        {
            _timer = 0;
            foreach (var creator in _creators)
            {
                creator.Create(_enemyPrefab, transform);
            }
        }
    }
}
