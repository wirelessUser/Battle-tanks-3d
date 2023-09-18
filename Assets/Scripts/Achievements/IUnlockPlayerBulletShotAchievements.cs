using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnlockPlayerBulletShotAchievements
{
    public void CheckBulletAchivementUnlock(int enemyId, int playerId, EnemyTankType enemyType, int bullets);
}
