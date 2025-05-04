using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialSize = 10;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < initialSize; i++)
            AddObjectToPool();
    }

    private void AddObjectToPool()
    {
        var obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    public GameObject Get()
    {
        if (pool.Count == 0)
            AddObjectToPool();

        var obj = pool.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
