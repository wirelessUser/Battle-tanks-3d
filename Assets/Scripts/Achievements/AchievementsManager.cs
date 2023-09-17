using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    public ListAchivements achievements;

    //Is it a betetr Approach to create ithis class as singleton Or Should I  give its reference in the Player View Script    ?

    // Becuase i will Create All kind of Achievemtn In That Script Only ,So Suppose Now i am creating The  Bullet related Achievemnts in this Script ,
    // then Should i first Give the Refrence of that Script in the "PlayerView.cs" Script ? and "PlayerView.cs" will Handle The Achivements According to its use case Right ?

    //Or Instead of "PlayerView.cs" ,Should i pass it's refrnce in the Player Service class ?

    //Same For Enemy i will Have a Sepaarte Achiveement Script And pass its refrnce in the "EnemyView.cs" Script ?


    public void UnlockAchievements(AchievementsType type)
    {

    }
}
