using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    private BulletView view;
    private BulletModel model;

    private Rigidbody bulletRb;

    public BulletController(BulletView _view, BulletModel _model)
    {
        Debug.Log($"Bullet view From controlelr ...");
        BulletView newView = Object.Instantiate(_view);
      
        view = newView;
        model = _model;
        bulletRb = view.gameObject.GetComponent<Rigidbody>();
        if (bulletRb == null)
        {
            Debug.Log($"bullet rb is NULL");
        }
        view.SetBulletController(this);
        model.SetBulletController(this);




    }

   


}
