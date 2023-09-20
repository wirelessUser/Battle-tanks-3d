using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolingScript : ObjectPoolingGeneric<BulletController>
{
    public BulletModel  bulletModel;
    public BulletView bulletPrefab;



   public BulletController CreateItemFromBulletPool(BulletModel _bulletModel, BulletView _bulletPrefab)
    {
        bulletModel = _bulletModel;
        bulletPrefab = _bulletPrefab;
        return CreateItem();
    }

    public override BulletController CreateItem()
    {
        BulletController controller = new BulletController(bulletPrefab, bulletModel);
        return controller;
    }
}