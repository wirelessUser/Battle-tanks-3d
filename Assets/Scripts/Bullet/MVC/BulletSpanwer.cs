using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpanwer : EventManager<BulletSpanwer> , IBulletSpawn
{

   
    public GameObject[] view;

    public  void SpawnBullet(Transform spawnPoint, BulletEnum bulletType,GameObject owner) // passing the Ownr gaemObject to Know that (the spawner is enemy Or Player) ,
                                                                                           // So  The Bullet Will Give Damage Accordingly( to mkae sure that Is slould Not give
                                                                                           // Damage  to it's Owner/Spawner.
    {
        GameObject bulletSpawned = null;
       
        bulletSpawned = Instantiate(view[(int)bulletType]) ;
    
        bulletSpawned.GetComponent<BulletView>().SetOwner(owner);

        bulletSpawned.transform.localPosition = spawnPoint.position;
        bulletSpawned.transform.localRotation = spawnPoint.rotation;

        float speed = bulletSpawned.GetComponent<BulletView>().bulletSo.speed;

        bulletSpawned.GetComponent<Rigidbody>().AddForce((spawnPoint.forward * speed), ForceMode.Force);

    }
   

}
