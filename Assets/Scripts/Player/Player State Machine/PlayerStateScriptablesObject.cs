using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "ScriptableObject", menuName = "ScriptableObject/TanksStates")]
public class PlayerStateScriptablesObject : ScriptableObject
{
    public float walkSpeed;


    //.*******************************DOUBT******************************************************************************

    //// Is ther any need to Implement  States MAchine for Player Or should i handle Shoot,Run,walk jump etc. Behvaiours of player in the Player Model,view,Controller?

    //  Becuase if We implenent  the Different Player States then For shoot,jump,Run etc.  Means  for each state of layer  we will have different script and after attaching those scripts  to the  player ,There will Be
    // no interaction from playerView Or Controller will be needed For these states .

    //.*******************************DOUBT******************************************************************************



}
