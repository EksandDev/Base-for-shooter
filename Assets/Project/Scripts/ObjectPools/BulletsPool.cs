using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _bulletsCount = 20;

    private ObjectsPool<Bullet> _currentPool;

    public Bullet CreateBullet(Vector3 spawnPosition)
    {
        var obj = _currentPool.GetObject(spawnPosition);
        return obj;
    }

    private void Awake()
    {
        _currentPool = new ObjectsPool<Bullet>(_bulletPrefab, _bulletsCount);
    }
}
