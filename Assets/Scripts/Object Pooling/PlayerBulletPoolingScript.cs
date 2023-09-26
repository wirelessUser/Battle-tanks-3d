using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPoolingScript : EventManager<PlayerBulletPoolingScript>
{
    public BulletView[] view;

    public Transform[] parent;

    public int bulletPoolCount;

   

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



    public void SpawnBullet(PlayerBullet bulletType, int poolId, int ownerId, Transform SpawnPoint)
    {

        BulletView newBulletView = genericBulletPool[(int)bulletType].GetItemFromPool();
        newBulletView.SetOwner(newBulletView.gameObject, ownerId, bulletType);
        newBulletView.bulletSo = scriptableSo[0];
        BulletModel newBulletModel = new BulletModel(scriptableSo[0]);

        BulletController newController = new BulletController(newBulletView, newBulletModel);


        SetBulletFortank(newBulletView, SpawnPoint);
    }



    public void DestroyBullet(PlayerBullet bulletType,BulletView view)
    {
       
        view.transform.localRotation = parent[(int)bulletType].transform.rotation;
        view.gameObject.transform.SetParent(parent[(int)bulletType]);

        genericBulletPool[(int)bulletType].SentBackTOToPool(view);
    }
    public void SetBulletFortank(BulletView newBulletView, Transform SpawnPoint)
    {


        newBulletView.gameObject.transform.position = SpawnPoint.position;
        newBulletView.gameObject.transform.localRotation = SpawnPoint.rotation;
        newBulletView.gameObject.SetActive(true);

        newBulletView.GetComponent<Rigidbody>().velocity = SpawnPoint.forward * 30;
    }
}
