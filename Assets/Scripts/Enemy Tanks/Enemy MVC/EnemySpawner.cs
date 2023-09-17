using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : EventManager<EnemySpawner>
{
  
    public EnemyModel model;
    public List<EnemyView> enemyPrefab;
    public Transform[] spawnPoints;
    public Vector3 offset;
   public override void Awake()
    {
        base.Awake();
        //model = new EnemyModel();
       


    }

    private void Start()
    {
        SpawneEnemy();
    }
    //private void Start()
    //{
    //    transform.position = offset;
    //    EnemyController controller = new EnemyController(view, model);
    //    controller.InstantiateEnemies(enemyPrefab, spawnPoints);
    //}

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

}
