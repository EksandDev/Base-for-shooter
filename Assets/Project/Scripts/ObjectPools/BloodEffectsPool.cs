using UnityEngine;

public class BloodEffectsPool : MonoBehaviour
{
    [SerializeField] private BloodEffect _prefab;
    [SerializeField] private int _effectsCount = 20;

    private ObjectsPool<BloodEffect> _currentPool;

    public BloodEffect CreateEffect(Vector3 spawnPosition)
    {
        return _currentPool.GetObject(spawnPosition);
    }

    private void Awake()
    {
        _currentPool = new ObjectsPool<BloodEffect>(_prefab, _effectsCount);
    }
}
