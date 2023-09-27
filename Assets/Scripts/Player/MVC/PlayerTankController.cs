using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController 
{

    public PlayerTankModel model;
    public PlayerTankView view;
    public Rigidbody rb;

    
    public void PlayerTankControllerSetting(PlayerTankModel _model, PlayerTankView _view, PlayerTankView _playerView)
    {
        model = _model;
       
        view = _playerView;
     
        model.SetController(this);
        
        model.SetPlayerTankModel(view.dataSo);
       
        rb = _playerView.GetComponent<Rigidbody>();
     
        _playerView.SetController(this);
        _playerView.gameObject.name = model.name;
    }



    public  void Move(float moveDir)   
    {                          
  

      
        rb.velocity = view.transform.forward * moveDir *model.movementSpeed*Time.deltaTime;
       
    
    }
    public void Rotation( float rotateDir)  
    {
        
         Quaternion rotationAngle = Quaternion.Euler(new Vector3(0f, rotateDir, 0f));


       rb.MoveRotation(rb.rotation * rotationAngle);

    }


    public void ShootBullet(BulletCategory playerBulletType,int poolId,Transform spawnPoint, Transform tankTransform,BulletType bulletType)
    {

        if (view.gameObject != null)
        {
            BulletService.Instance.SpawnBullet( view.gameObject, playerBulletType, poolId,model.id, spawnPoint, tankTransform,bulletType);
            //bulletCount++;


        }
       

    }



}
