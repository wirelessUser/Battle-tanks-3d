using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController 
{

    public PlayerTankModel model;
    public PlayerTankView view;
    public Rigidbody rb;

    
    public void PlayerTankControllerSetting(PlayerTankModel _model, PlayerTankView _view)
    {
       // Debug.Log("Inside the **PlayerTankControllerSetting ");
        model = _model;
       
        view = _view;
     
        model.SetController(this);
        
        model.SetPlayerTankModel(view.dataSo);
       PlayerTankView newView= Object.Instantiate(view.gameObject).GetComponent<PlayerTankView>();
        rb = newView.ReturnRb();
        if (rb == null)
        {
            Debug.Log("Rigidbody is null in PlayerTankController");
        }
        else
        {
            Debug.Log("Rigidbody is assigned in PlayerTankController");
        }
        newView.SetController(this);
        newView.gameObject.name = model.name;
    }



    public  void Move(float moveDir)     //*****DOUBT, I am calling that Method from Player view But it's Not working(*Player Not moving) , But when i am writing thaat movement code In the view Script thenplayer is moving 
    {                          
  

      
        rb.velocity = view.transform.forward * moveDir *500*Time.deltaTime;
       
    
    }
    public void Rotation( float rotateDir)  //*****DOUBT, I am calling that Method from Player view But it's Not working (*Player Not Rotating) , But when i am writing thaat Rotation code In the view Script then player is Rotating 
    {
        
         Quaternion rotationAngle = Quaternion.Euler(new Vector3(0f, rotateDir, 0f));


       rb.MoveRotation(rb.rotation * rotationAngle);

    }
}
