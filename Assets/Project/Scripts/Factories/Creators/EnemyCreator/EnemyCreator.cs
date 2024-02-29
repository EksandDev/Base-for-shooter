using UnityEngine;

public abstract class EnemyCreator : MonoBehaviour
{
    public abstract void Create(GameObject enemyPrefab, Transform spawnpoint);
}
