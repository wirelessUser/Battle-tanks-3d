using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletSpawn 
{
    public void SpawnBullet(Transform spawnPoint, BulletEnum bulletType, GameObject owner, int OwnerId);
}
