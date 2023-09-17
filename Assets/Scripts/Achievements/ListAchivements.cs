using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Achivements",menuName = "Achivements/AchivementsList")]
public class ListAchivements : ScriptableObject
{
    public List<AchivemetsScriptableObject> AchivementsList;
}
