using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController 
{
    public EnemyView view;
    public EnemyModel model;

   
  
    public  EnemyController(EnemyView _view, EnemyModel _model)
    {
        view = _view;
        model = _model;

        view.SetEnemyController(this);
        model.SetEnemyController(this);

    }

    //public void ShootBullet(BulletEnum bulletType,  Transform spawnPoint)
    //{

    //    if (view.gameObject != null)
    //    {
    //        EnemyBulletPooling.Instance.SpawnBullet(bulletType, model.id, spawnPoint);
          


    //    }


    //}
}
