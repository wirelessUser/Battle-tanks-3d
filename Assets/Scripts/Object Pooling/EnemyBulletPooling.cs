using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPooling : EventManager<EnemyBulletPooling>
{
    public BulletView view;

    public Transform parent;

    public int bulletPoolCount;

 

    public GenericObjectPooling<BulletView>  genericBulletPool;
    public BulletScriptableObject scriptableSo;



    private void Start()
    {
        
            genericBulletPool = new GenericObjectPooling<BulletView>();
            genericBulletPool.CreatePool(view.gameObject, parent, bulletPoolCount);

        
    }


    public void SpawnBullet(BulletEnum bulletType, int ownerId, Transform SpawnPoint,GameObject Owner)
    {

        BulletView newBulletView = genericBulletPool.GetItemFromPool();
       // newBulletView.SetOwner(Owner, ownerId, bulletType);
        newBulletView.bulletSo = scriptableSo;
        BulletModel newBulletModel = new BulletModel(scriptableSo);

        BulletController newController = new BulletController(newBulletView, newBulletModel);


        SetBulletFortank(newBulletView, SpawnPoint);
    }


    //public void DestroyBullet(GameObject bulletObejct)
    //{
        
    //}

    public void SetBulletFortank(BulletView newBulletView, Transform SpawnPoint)
    {
        newBulletView.transform.position = SpawnPoint.position;
        newBulletView.transform.localRotation = SpawnPoint.rotation;
        newBulletView.gameObject.SetActive(true);

        newBulletView.GetComponent<Rigidbody>().AddForce(SpawnPoint.forward * 600, ForceMode.Force);
    }
}
