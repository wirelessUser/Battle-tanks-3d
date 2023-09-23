using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingGeneric<T> : MonoSingletonGeneric<ObjectPoolingGeneric<T>> where T:class
{
    public List<PooledItem<T>> pooledItemsList;
    public virtual T GetItem()
    {
        // if already availalble...
        if (pooledItemsList.Count > 0)
        {
            PooledItem<T> newItem = pooledItemsList.Find(i => i.isUsed == false);

            if (newItem != null)
            {
                newItem.isUsed = true;
                return newItem.item;

            }

        }
        // otherwise create new item and return to the pool...
        return CreateNewItem();

    }

    private T CreateNewItem()
    {
        PooledItem<T> newpooledItem = new PooledItem<T>();
        newpooledItem.item = CreateItem();
        newpooledItem.isUsed = true;
        pooledItemsList.Add(newpooledItem);

        return newpooledItem.item;
    }

    public virtual void ReturnItemToPool(T item)
    {
        PooledItem<T> pooledItem = pooledItemsList.Find(i => i.item.Equals(item));
        pooledItem.isUsed = false;
    }

    public virtual T  CreateItem()
    {
        return  null;
    }

    public class PooledItem<T>
    {
        public T item;
        public bool isUsed;
    }


}


