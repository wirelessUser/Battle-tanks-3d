using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController 
{
    public EnemyView view;
    public EnemyModel model;

    //public List<int> spawnPointList;

    //public List<int> EnemySpawnList;
  
    public  EnemyController(EnemyView _view, EnemyModel _model)
    {
        view = _view;
        model = _model;

        view.SetEnemyController(this);
        model.SetEnemyController(this);

    }

   
}
