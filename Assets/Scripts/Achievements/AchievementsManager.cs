using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsManager : MonoBehaviour, IUnlockPlayerBulletShotAchievements
{
    public ListAchivements achievements;

    //Is it a betetr Approach to create ithis class as singleton Or Should I  give its reference in the Player View Script    ?

    // Becuase i will Create All kind of Achievemtn In That Script Only ,So Suppose Now i am creating The  Bullet related Achievemnts in this Script ,
    // then Should i first Give the Refrence of that Script in the "PlayerView.cs" Script ? and "PlayerView.cs" will Handle The Achivements According to its use case Right ?

    //Or Instead of "PlayerView.cs" ,Should i pass it's refrnce in the Player Service class ?

    //Same For Enemy i will Have a Sepaarte Achiveement Script And pass its refrnce in the "EnemyView.cs" Script ?

    private void OnEnable()
    { 
        EnemySpawner.Instance.enemyBulletHitEvent += CheckBulletAchivementUnlock; 
    }


    private void OnDisable()
    {
        EnemySpawner.Instance.enemyBulletHitEvent -= CheckBulletAchivementUnlock;

    }
   public void GoodShotUnlocked()
    {
        Debug.Log("GoodShotUnlocked");
    }
    public void BetterShotUnlocked()
    {
        Debug.Log("BetetrShotUnlocked");
    }
    public void BestShotUnlocked()
    {
        Debug.Log("BestShotUnlocked");
    }



    public void CheckBulletAchivementUnlock(int enemyId, int playerId, EnemyTankType enemyType, int bullets)
    {
        switch (bullets)
        {
            case 1:
                BetterShotUnlocked();
                break;
            case 2:
                BetterShotUnlocked();
                break;

            case 3:
                BestShotUnlocked();
                break;

            default:
                break;
        }
    }
}
