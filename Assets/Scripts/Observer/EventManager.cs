using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager<T> : MonoBehaviour where T:EventManager<T>
{
    public static T Instance;

    public event Action onPlayerDeath;

    public event Action OnPlayerSpawned;

    public virtual void Awake()
    {

       MakeInstance();

    }

    private void MakeInstance()
    {
        if (Instance == null) { Instance = (T) this; DontDestroyOnLoad(gameObject); }
        else{ Destroy(gameObject); }
    }

    public void PlayerDeathEvent()
    {
        onPlayerDeath?.Invoke();

    }

    public void PlayerSpwnedEvent()
    {
        Debug.Log("Event called..");
        OnPlayerSpawned?.Invoke();
    }
}
