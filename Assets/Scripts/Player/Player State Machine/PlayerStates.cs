//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;



//.*******************************DOUBT******************************************************************************

//// Is ther any need to Implement  States MAchine for Player Or should i handle Shoot,Run,walk jump etc. Behvaiours of player in the Player Model,view,Controller?

//  Becuase if We implenent  the Different Player States then For shoot,jump,Run etc.  Means  for each state of layer  we will have different script and after attaching those scripts  to the  player ,There will Be
// no interaction from playerView Or Controller will be needed For these states .

//.*******************************DOUBT******************************************************************************























//public class PlayerStates : MonoBehaviour
//{
//    [SerializeField]
//    protected Color color;
//    protected PlayerScriptableObject playerdatSo;

//    private void Awake()
//    {
//       // playerdatSo = EventManager<PlayerTankSpawner>.Instance.playerDataSo;  
//    }
//    public virtual void OnPlayerEnterState()
//    {

//        this.enabled = true;
//    }

//    public virtual void OnPlayerExitState()
//    {
//        this.enabled = false;
//    }

//    public virtual void Update()
//    {

//    }
//}
