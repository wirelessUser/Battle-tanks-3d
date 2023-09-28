
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemySpawner : EventManager<EnemySpawner>
{
    public EnemyModel model;
    public List<AssetReferenceGameObject> enemyPrefabAddresable;
    public Transform[] spawnPoints;

    public override void Awake()
    {
        base.Awake();
        Debug.Log("Enemy Awake called....");
        SpawnEnemy();
    }
  


    public void SpawnEnemy()
    {
        Debug.Log("Enemy Start called....");
        for (int i = 0; i < enemyPrefabAddresable.Count; i++)
        {
            enemyPrefabAddresable[i].LoadAssetAsync().Completed += SpawneEnemy;
        }
    }
   

    public void SpawneEnemy(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject enemyPrefab = handle.Result;

         
                GameObject enemyInstance = Instantiate(enemyPrefab);

                enemyInstance.transform.position = spawnPoints[0].position;

                EnemyView enemyView = enemyInstance.GetComponent<EnemyView>();
                model = new EnemyModel();
                EnemyController controller = new EnemyController(enemyView, model);
                enemyView.InitializeID(model.enemyType);
           
        }
    }
}






