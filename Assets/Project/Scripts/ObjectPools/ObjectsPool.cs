using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool<T> where T : MonoBehaviour, IInPool
{
    public T Prefab { get; }
    public Transform Container { get; set; }

    private List<T> _pool;

    public ObjectsPool(T prefab, int prefabsCount)
    {
        Prefab = prefab;
        Container = null;

        CreatePool(prefabsCount);
    }

    public ObjectsPool(T prefab, int prefabsCount, Transform cointainer)
    {
        Prefab = prefab;
        Container = cointainer;

        CreatePool(prefabsCount);
    }

    public bool HasFreeObject(out T element)
    {
        foreach (var item in _pool)
        {
            if (!item.IsActive)
            {
                element = item;
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetObject(Vector3 spawnPosition)
    {
        if (HasFreeObject(out var element))
        {
            element.transform.position = spawnPosition;
            element.gameObject.SetActive(true);
            return element;
        }

        T currentObject = CreateObject(true);
        currentObject.transform.position = spawnPosition;
        return currentObject;
    }

    private void CreatePool(int prefabsCount)
    {
        _pool = new List<T>();

        for (int i = 0; i < prefabsCount; i++)
            CreateObject();
    }

    private T CreateObject(bool isActive = false)
    {
        var createdObject = Object.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActive);
        _pool.Add(createdObject);
        return createdObject;
    }
}
