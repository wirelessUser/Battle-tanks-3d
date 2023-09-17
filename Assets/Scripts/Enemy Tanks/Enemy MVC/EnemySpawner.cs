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

    //..............Events................
    public event Action<int, int, EnemyTankType, int> enemyBulletHitEvent;   // Enemyid,playerId,EnemyType,BulletAmount
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

            EnemyController controller = new EnemyController(enemyInst.GetComponent<EnemyView>(), new EnemyModel());

        }
         
    }

   
    public void EnemyBulletHitEvent(int PlayerId,int bulletHit,int enemymodelId,EnemyTankType enemyType)
    {
        enemyBulletHitEvent?.Invoke(enemymodelId, PlayerId, enemyType, bulletHit);
    }
}
