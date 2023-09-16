using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : EventManager<EnemySpawner>
{
    public EnemyView view;
    public EnemyModel model;
    public List<EnemyView> enemyPrefab;
    public Transform[] spawnPoints;
    public Vector3 offset;
   public override void Awake()
    {
        base.Awake();
        model = new EnemyModel();
      
     
    }


    private void Start()
    {
        transform.position = offset;
        EnemyController controller = new EnemyController(view, model);
        controller.InstantiateEnemies(enemyPrefab, spawnPoints);
    }

}
