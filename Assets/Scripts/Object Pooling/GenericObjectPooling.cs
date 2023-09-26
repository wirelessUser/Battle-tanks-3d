using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPooling<T>  
{

    Queue<T> ObjectPoolQue = new Queue<T>();
    public GameObject objectToPool;
    public Transform   parent;
    public int PoolCount;
    int poolCalled = 0;
    public T CreatePool(GameObject _objectToPool, Transform _parent, int _PoolCount)
    {
        objectToPool = _objectToPool;
        parent = _parent;
        PoolCount = _PoolCount;
        Debug.Log($"Creating the Pool ==  {poolCalled}");

        for (int i = 0; i < PoolCount; i++)
        {
            
            GameObject pooledObj = GameObject.Instantiate(objectToPool);
            pooledObj.transform.SetParent(parent);
            ObjectPoolQue.Enqueue(pooledObj.GetComponent<T>());
            pooledObj.SetActive(false);
           
        }
        poolCalled++;
        Debug.Log($"Number of items in the Pool ==  {ObjectPoolQue.Count}");
        return ObjectPoolQue.Dequeue();
       
    }



    public T GetItemFromPool()
    {
       
        if (ObjectPoolQue.Count > 0)
        {

            return ObjectPoolQue.Dequeue();
        }


        return CreateNewPooledItem(objectToPool, parent);
    }

    private T CreateNewPooledItem(GameObject objectToPool, Transform parent)
    {
        GameObject newItem = GameObject.Instantiate(objectToPool);
        newItem.transform.SetParent(parent);
        newItem.SetActive(false);
        T newpooleditem = newItem.GetComponent<T>();
        ObjectPoolQue.Enqueue(newpooleditem);
        return ObjectPoolQue.Dequeue();
    }

    public void SentBackTOToPool(T PooledItem)
    {
        GameObject newPooledItem = PooledItem as GameObject;
        ObjectPoolQue.Enqueue(PooledItem);
       
       

    }
}
