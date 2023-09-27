using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : EventManager<BulletService>
{
    public BulletView view;

    public Transform[] parent;

    public int bulletPoolCount;



    public GenericObjectPooling<BulletView>[] playerGenericBulletPool = new GenericObjectPooling<BulletView>[4];
    public List<BulletScriptableObject> scriptableSo;

    public bool Poolgenerated = false;
   

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            playerGenericBulletPool[i] = new GenericObjectPooling<BulletView>();
            playerGenericBulletPool[i].CreatePool(view.gameObject, parent[i], bulletPoolCount);


        }
    }



    public BulletScriptableObject GetScriptableObejct(int poolId)
    {
        return scriptableSo[poolId];
    }

    public void SpawnBullet(GameObject Owner, BulletCategory bulletCategory, int poolId, int ownerId, Transform spawnPoint, Transform tankTransform, BulletType bulletType)
    {
      
        BulletView newBulletView = playerGenericBulletPool[poolId].GetItemFromPool();
        newBulletView.SetOwner(Owner, ownerId, GetScriptableObejct(poolId));
    
        if (Poolgenerated == false)
        {
            newBulletView.bulletSo = GetScriptableObejct(poolId);
            BulletModel newBulletModel = new BulletModel(GetScriptableObejct(poolId));

            BulletController newController = new BulletController(newBulletView, newBulletModel);

        }


        SetBulletFortank(newBulletView, spawnPoint,tankTransform);
        Poolgenerated = true;
    }



    public void DestroyBullet(int poolId, BulletView view)
    {
        view.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        view.gameObject.transform.SetParent(parent[poolId]);

        playerGenericBulletPool[poolId].SentBackTOToPool(view);
    }
    public void SetBulletFortank(BulletView newBulletView, Transform spawnPoint,Transform tankTransform)
    {


        newBulletView.gameObject.transform.position = spawnPoint.position;
        newBulletView.gameObject.transform.localRotation = tankTransform.localRotation;
        newBulletView.gameObject.SetActive(true);

        newBulletView.GetComponent<Rigidbody>().velocity = tankTransform.forward * 20;

        //freezing the roataion To avoid Rotation issue.............................................
        // newBulletView.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}
