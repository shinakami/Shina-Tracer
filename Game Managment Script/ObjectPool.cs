using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary = new Dictionary<string, Queue<GameObject>>();
    public Queue<GameObject> objectPool = new Queue<GameObject>();
    private GameObject objectToSpawn;
    #region Singleton
    public static ObjectPool Instance;
    void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        foreach (Pool pool in Pools)
        {

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public void AddObjectToPool(GameObject obj, Vector3 position, Quaternion rotation)
    {

        GameObject poolObject = Instantiate(obj, position, rotation);
            
        poolObject.SetActive(false);
        objectPool.Enqueue(poolObject);
        
    }
    public IEnumerator RecycleObject(string tag, GameObject obj, float duration)
    {
        while (duration > 0)
        {
            duration--;
            yield return new WaitForSeconds(1);
        }
        obj.SetActive(false);

        PoolDictionary[tag].Enqueue(obj);
        
    }
    
    public GameObject SpawnFromPool(string tag, GameObject obj, Vector3 position, Quaternion rotation)
    {

        if (!PoolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag: " + tag + " doesn't excist");
            return null;
        }
        if (PoolDictionary[tag].Count <= 0)
        {
            AddObjectToPool(obj, position, rotation);
        }
        
        obj = PoolDictionary[tag].Dequeue();

        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        


        return obj;
    }

}
