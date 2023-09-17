using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingBehaviour : MonoBehaviour,IShootBullet
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public BulletSpanwer bulletSpawner;

    public PlayerTankView playerRef;

    private int  bulletCount;
    private void Start()
    {
        playerRef = PlayerTankSpawner.Instance.ReturnView();
    }
    public  void ShootBullet()
    {

        if (playerRef != null)
        {
            bulletSpawner.SpawnBullet(spawnPoint, BulletEnum.PlayerBullet, this.gameObject);

            bulletCount++;
            
            
        }
        if (bulletCount >= 10)
        {
            CheckBulletAchivementUnlock(bulletCount);
        }

    }


    public void CheckBulletAchivementUnlock(int bullets)
    {
        switch (bullets)
        {
            case 10 :
                PlayerTankSpawner.Instance.achivementManager.UnlockAchievements(AchievementsType.GoodShots);
                break;
            case 20:
                PlayerTankSpawner.Instance.achivementManager.UnlockAchievements(AchievementsType.BetterShots);
                break;

            case 30:
                PlayerTankSpawner.Instance.achivementManager.UnlockAchievements(AchievementsType.BestShots);
                break;

            default:
                break;
        }
    }
}
