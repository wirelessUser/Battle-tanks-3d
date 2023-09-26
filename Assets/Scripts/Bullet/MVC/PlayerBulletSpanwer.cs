using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpanwer : EventManager<PlayerBulletSpanwer>
{


    public BulletView[] view;

    public Transform[] parent;

    public int bulletPoolCount;

    //  public Transform SpawnPoint;

    public GenericObjectPooling<BulletView>[] genericBulletPool = new GenericObjectPooling<BulletView>[3];
    public List<BulletScriptableObject> scriptableSo;



    private void Start()
    {
        for (int i = 0; i < view.Length; i++)
        {
            genericBulletPool[i] = new GenericObjectPooling<BulletView>();
            genericBulletPool[i].CreatePool(view[i].gameObject, parent[i], bulletPoolCount);

        }
    }


    //Where to set This Controlelr and Model For Every Bullet ?  At the time of Spawn or 
    public void SpawnBullet(PlayerBullet bulletType, int poolId, int ownerId, Transform SpawnPoint)
    {

        BulletView newBulletView = genericBulletPool[poolId].GetItemFromPool();
        newBulletView.SetOwner(newBulletView.gameObject, ownerId, bulletType);
        newBulletView.bulletSo = scriptableSo[0];
        BulletModel newBulletModel = new BulletModel(scriptableSo[0]);

        BulletController newController = new BulletController(newBulletView, newBulletModel);


        SetBulletFortank(newBulletView, SpawnPoint);
    }


    public void SetBulletFortank(BulletView newBulletView, Transform SpawnPoint)
    {
        newBulletView.transform.position = SpawnPoint.position;
        newBulletView.transform.localRotation = SpawnPoint.rotation;
        newBulletView.gameObject.SetActive(true);

        newBulletView.GetComponent<Rigidbody>().AddForce(SpawnPoint.forward * 600, ForceMode.Force);
    }

}
