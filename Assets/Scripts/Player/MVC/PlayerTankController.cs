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
       // Debug.Log("Inside the **PlayerTankControllerSetting ");
        model = _model;
       
        view = _playerView;
     
        model.SetController(this);
        
        model.SetPlayerTankModel(view.dataSo);
        //  PlayerTankView newView= Object.Instantiate(view.gameObject).GetComponent<PlayerTankView>();
        rb = _playerView.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.Log("Rigidbody is null in PlayerTankController");
        }
        else
        {
            Debug.Log("Rigidbody is assigned in PlayerTankController");
        }
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
}
