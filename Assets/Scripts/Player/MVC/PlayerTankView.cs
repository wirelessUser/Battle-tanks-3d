using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerTankView : MonoBehaviour, IGetComponentsInAwake
{
    public PlayerTankController tankController;

    public float horizontalInput;
    public float verticleInput;

    public PlayerScriptableObject dataSo;
    public CameraFollow mainCam;
    public Rigidbody rb;

   // public PlayerBulletSpanwer bulletSpawner;

    public Transform spawnPoint;

   // public PlayerShootingBehaviour shootingBehaviour;

   // public BulletEnum bulletType;

    private int[] poolId = new int[]
    {
        1,2,3
    };
  
    private void Awake()
    {
        GetComponenetsInAwake();
    }

    public void GetComponenetsInAwake()
    {
      
         mainCam =  Camera.main.GetComponent<CameraFollow>();
        mainCam.CameraSetup(this);
    }
    private void Update()
    {
        TakeInput();
       tankController.Move(horizontalInput); 
        tankController.Rotation(verticleInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBulletLowDamage();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FireBulletHighDamage();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            FireBulletOneShotDamage();
        }
    }

    public void SetController(PlayerTankController _tankController)     // Controller is Seeting those value So tankController of TankView can Be Initilaized.
    {
        tankController = _tankController; 
    }



    public void TakeInput()   
    {

        horizontalInput = Input.GetAxis("Vertical1");
        verticleInput = Input.GetAxis("Horizontal1");
    }

    public Rigidbody ReturnRb()    
    {
        return rb;        // return the rigidBody To the Player Controller...
        
    }

  



    public void FireBulletLowDamage()       
    {
        tankController.ShootBullet(PlayerBullet.LowDamage,poolId[0]-1, spawnPoint);  
        
    }

    public void FireBulletHighDamage()
    {
        tankController.ShootBullet(PlayerBullet.HighDamage, poolId[1] - 1, spawnPoint);

    }

    public void FireBulletOneShotDamage()
    {
        tankController.ShootBullet(PlayerBullet.OneSHotDamage, poolId[2] - 1, spawnPoint);

    }
}
