﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }


    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + "doesn't exist");
            return null;
        }


        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();
        
        if (pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }
        
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
    private void CheckForDuplicates(GameObject currentObject)
    {
        RaycastHit[] hitObject = Physics.SphereCastAll(currentObject.transform.position, 10f, Vector3.zero);
        for (int i = 0; i < hitObject.Length; i++)
        {
            if (hitObject[i].collider.gameObject.layer == LayerMask.NameToLayer("Tree")) ;
            {
                currentObject.SetActive(false);
            }
        }
    }
}