using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AchievementsManager : EventManager<AchievementsManager>, IUnlockPlayerBulletShotAchievements
{
    public ListAchivements achievements;


  
    public bool allBulletAchivementUnlocked=false;
    public int BulletHitCountEnemy;
  
    public void GoodShotUnlocked(int playerId, EnemyTankType enemyType)
    {
        Debug.Log($"GoodShotUnlocked by {playerId} Shot {enemyType}");
    }
    public void BetterShotUnlocked(int playerId, EnemyTankType enemyType)
    {
        Debug.Log($"BeterrShotUnlocked by {playerId} Shot {enemyType}");
    }
    public void BestShotUnlocked(int playerId, EnemyTankType enemyType)
    {
        Debug.Log($"BestShotUnlocked by {playerId} Shot {enemyType}");

        allBulletAchivementUnlocked = true;
    }



    public void CheckBulletAchivementUnlock( int playerId, EnemyTankType enemyType)
    {
       
        switch (BulletHitCountEnemy)
        {
            case 1:
                GoodShotUnlocked(playerId, enemyType);
                break;
            case 2:
                BetterShotUnlocked(playerId, enemyType);
                break;

            case 3:
                BestShotUnlocked( playerId,  enemyType);
                break;

            default:
                break;
        }
    }
}
