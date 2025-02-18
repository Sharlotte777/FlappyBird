using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    private List<T> _pool = new List<T>();

    public IEnumerable<T> PooledObjects => _pool;

    public ObjectPool(T prefab)
    {
        _prefab = prefab;
    }

    public T GetObject()
    {
        T item = null;

        foreach (var checkItem in _pool)
        {
            if (checkItem.isActiveAndEnabled == false)
            {
                item = checkItem;
                break;
            }
        }

        if (item == null)
        {
            item = Object.Instantiate(_prefab);
            _pool.Add(item);
        }

        return item;
    }

    public void PutObject(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void Reset()
    {
        foreach (var item in _pool)
        {
            item?.gameObject.SetActive(false);
        }
    }
}
