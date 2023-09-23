using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpanwer : EventManager<BulletSpanwer> 
{

   
    public BulletView view;
    public BulletPoolingScript bulletPooling;

    public List<BulletScriptableObject> listBulletSo;
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateNewBullet(0);


        }
    }



    private BulletController CreateNewBullet(int index)
    {
        BulletScriptableObject bulletSo = listBulletSo[index] ;

        Debug.Log($" Bullet scriptable Object name {bulletSo.name} and index= {index}");

        BulletModel newBulletModel = new BulletModel(bulletSo);

        BulletController newController = bulletPooling.CreateItemFromBulletPool(newBulletModel, view);

        return newController;

    }

   
}
