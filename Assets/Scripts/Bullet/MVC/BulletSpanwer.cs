using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpanwer : EventManager<BulletSpanwer> , IBulletSpawn
{

   
    public GameObject[] view;
    public BulletPoolingScript bulletPooling;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
          //  GameObject bulletSpawned = null;
           
        }
    }

    public void SpawnPlayerBullet()
    {

    }

    //public BulletView SpawnNewBullet()
    //{
    //   // BulletController controller = bulletPooling.CreateItemFromBulletPool(bulletSpawned.GetComponent<BulletModel>(), bulletSpawned.GetComponent<BulletView>());
    //   // return controller;
    //}
    public  void SpawnBullet(Transform spawnPoint, BulletEnum bulletType,GameObject owner,int OwnerId) // passing the Ownr gaemObject to Know that (the spawner is enemy Or Player) ,
                                                                                                       // So  The Bullet Will Give Damage Accordingly( to mkae sure that Is slould Not give
                                                                                                       // Damage  to it's Owner/Spawner.
    {
       

        //  bulletSpawned = Instantiate(view[(int)bulletType]);

      
           // BulletSettings(spawnPoint, owner, OwnerId, bulletSpawned);
           
        

       

    }

    private static void SpawnPlayerBullet(Transform spawnPoint, GameObject owner, int OwnerId, GameObject bulletSpawned)
    {
        bulletSpawned.GetComponent<BulletView>().SetOwner(owner, OwnerId);
        
        bulletSpawned.transform.localPosition = spawnPoint.position;
        bulletSpawned.transform.localRotation = spawnPoint.rotation;

        float speed = bulletSpawned.GetComponent<BulletView>().bulletSo.speed;

        bulletSpawned.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * speed, ForceMode.Force);
    }


    private static void SpawnEnemyBullet(Transform spawnPoint, GameObject owner, int OwnerId, GameObject bulletSpawned)
    {
        bulletSpawned.GetComponent<BulletView>().SetOwner(owner, OwnerId);

        bulletSpawned.transform.localPosition = spawnPoint.position;
        bulletSpawned.transform.localRotation = spawnPoint.rotation;

        float speed = bulletSpawned.GetComponent<BulletView>().bulletSo.speed;

        bulletSpawned.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * speed, ForceMode.Force);
    }

}
