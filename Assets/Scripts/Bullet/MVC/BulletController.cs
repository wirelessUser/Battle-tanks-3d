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
        Debug.Log($"Controller get setted for =  {_view.gameObject.name}");
       // BulletView newView = GameObject.Instantiate(_view);
      
        view = _view;
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
