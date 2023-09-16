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

    public BulletSpanwer bulletSpawner;

    public Transform spawnPoint;

    public PlayerShootingBehaviour shootingBehaviour;

  
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
      // tankController.Move(horizontalInput); // I am calling it from Player Controlelr But Player is not moving **Meansit's Not working  .
       // tankController.Rotation(verticleInput);// I am calling it from Player Controlelr But Player is not Rotating,**Means it's Not working 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    public void SetController(PlayerTankController _tankController)     // Controller is Seeting those value So tankController of TankView can Be Initilaized.
    {
        tankController = _tankController; 
    }



    public void TakeInput()   
    {

        horizontalInput = Input.GetAxis("Horizontal1");
        verticleInput = Input.GetAxis("Vertical1");

        rb.velocity = transform.forward * verticleInput * 50;    // ********DOUBT Player Movement Left Right (Currently I am Facing Issue Becuase i have wrote this
       // Code in the Contollr But from there it is not moving and i am not able to figure out why ?,But Writing that code Here is working fine ************


        Quaternion rotationAngle = Quaternion.Euler(new Vector3(0f, horizontalInput, 0f));// This rotation have same issue (this code is working from here correctly But 
                                                                                          // from the Controlelr it's not working.


        rb.MoveRotation(rb.rotation * rotationAngle);
    }

    public Rigidbody ReturnRb()    
    {
        return rb;        // return the rigidBody To the Player Controller...
        
    }

  



    public void FireBullet()        // Do i have to calling that *ShootBUllet() Method Directly from view OR Should i Call that  *ShootBullet() Method from controller And from the view
                                    // i should call that Method of the Controller Which is calling that *ShootBulletr() Method ?

        //  Means i want to ask that Sholuld i Do Every INetraction of view With External Script through the Controller ?  Or can i directly Call Other Scripts from View?
    {
        shootingBehaviour.ShootBullet();  
        
    }


}
