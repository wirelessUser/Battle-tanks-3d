using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemySpawner : EventManager<EnemySpawner>
{
  
    public EnemyModel model;
    public List<EnemyView> enemyPrefab;
    public Transform[] spawnPoints;
    public Vector3 offset;
    public EnemyAttckState enemyAttack;
   
   public override void Awake()
    {
        base.Awake();
    }

  
    private void Start()
    {
        SpawneEnemy();
     
    }
   
    public void SpawneEnemy()
    {
        int i = 0;
        for (; i < enemyPrefab.Count; i+=1)
        {
            EnemyView enemyInst = Instantiate(enemyPrefab[i]);
            enemyInst.transform.position = spawnPoints[i].position ;
            model = new EnemyModel();
             EnemyController controller = new EnemyController(enemyInst.GetComponent<EnemyView>(), model);
          
            enemyInst.GetComponent<EnemyView>().InitializeID( model.enemyType);
        }
         
    }

   
}
