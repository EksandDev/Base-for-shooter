using UnityEngine;

public class CubeCreator : EnemyCreator
{
    public override void Create(GameObject enemyPrefab, Transform spawnpoint)
    {
        Instantiate(enemyPrefab, spawnpoint.position, Quaternion.identity);
    }
}
