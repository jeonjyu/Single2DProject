using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolManager<T> where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _size;
    [SerializeField] private Queue<T> _pool = new Queue<T>();

    public ObjectPoolManager(T prefab, int size)
    {
        Debug.Log("[ObjectPoolManager] »ý¼ºÀÚ");
        this._prefab = prefab;
        _pool = new Queue<T>();

        for(int i = 0; i < size; i++)
        {
            T instance = Object.Instantiate(_prefab);
            instance.gameObject.SetActive(false);
            _pool.Enqueue(instance);
        }
    }

    public T GetObject()
    {
        if(_pool.Count > 0)
        {
            T returnObject = _pool.Dequeue();
            returnObject.gameObject.SetActive(true);
            return returnObject;
        }

        T newObject = Object.Instantiate(_prefab);
        return newObject;
    }

    public void ReturnObject(T gameObject)
    {
        _pool.Enqueue(gameObject);
        gameObject.gameObject.SetActive(false);
    }
}
