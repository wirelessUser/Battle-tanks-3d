using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Achivements", menuName = "Achivements/PlayersAchivements")]
public class AchivemetsScriptableObject : ScriptableObject
{

    public string achivementName;
    //public Sprite icon;
   
    public AchievementsType type;
    [Tooltip("Checked=UnLocked & Unchecked=Locked")]
    public bool isUnlocked;
    public string Desription;


}
