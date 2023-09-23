using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MonoSingletonGeneric<T> :MonoBehaviour where T:MonoSingletonGeneric<T>
{
    private static  T instance;

    public static T Instance { get { return instance; } set { } }

    private void Awake()
    {
        MakeInstance();


    }

   


    public void MakeInstance()
    {

        if (Instance == null)
        {
            Instance = (T) this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

