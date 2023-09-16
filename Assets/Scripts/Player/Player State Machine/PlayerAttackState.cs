//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;




//.*******************************DOUBT******************************************************************************

//// Is ther any need to Implement  States MAchine for Player Or should i handle Shoot,Run,walk jump etc. Behvaiours of player in the Player Model,view,Controller?

//  Becuase if We implenent  the Different Player States then For shoot,jump,Run etc.  Means  for each state of layer  we will have different script and after attaching those scripts  to the  player ,There will Be
// no interaction from playerView Or Controller will be needed For these states .

//.*******************************DOUBT******************************************************************************

























//public class PlayerAttackState : PlayerStates, IShootBullet
//{
//    public Transform spawnPoint;
//    public GameObject bulletPrefab;
//    public BulletSpanwer bulletSpawner;

//    public PlayerTankView playerRef;
//    private  void Awake()
//    {
//        playerRef = FindFirstObjectByType<PlayerTankView>();
//    }
//    public override void OnPlayerEnterState()
//    {
//        base.OnPlayerEnterState();
//    }
//    public override void OnPlayerExitState()
//    {
//        base.OnPlayerExitState();   

//    }
//    public  override void Update()
//    {      
//        if (Input.GetKeyDown(KeyCode.Space)){ShootBullet();}
//    }
//    public void ShootBullet()
//    {
//        if (playerRef != null)
//            bulletSpawner.SpawnBullet(spawnPoint, BulletEnum.PlayerBullet, this.gameObject);

//    }
//}
