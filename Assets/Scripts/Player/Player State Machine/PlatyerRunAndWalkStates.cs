//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//.*******************************DOUBT******************************************************************************

//// Is ther any need to Implement  States MAchine for Player Or should i handle Shoot,Run,walk jump etc. Behvaiours of player in the Player Model,view,Controller?

//  Becuase if We implenent  the Different Player States then For shoot,jump,Run etc.  Means  for each state of layer  we will have different script and after attaching those scripts  to the  player ,There will Be
// no interaction from playerView Or Controller will be needed For these states .

//.*******************************DOUBT******************************************************************************










//public class PlatyerRunAndWalkStates : PlayerStates
//{
//    public float horizontalMovement;
//    public float verticalMovement;
//    public Rigidbody rb;
//    public float moveSpeed;
//    public float rotationSpeed;
//    public override void OnPlayerEnterState()
//    {
//        base.OnPlayerEnterState();
//    }
//    public override void OnPlayerExitState()
//    {
//        base.OnPlayerExitState();
//    }
//    public override void Update()
//    {
//        base.Update();
//        GetInput();
//        PlayerMovement();
//        PlayerRotation();
//    }
//    public void GetInput()
//    {
//        verticalMovement  = Input.GetAxis("Horizontal1");
//        horizontalMovement = Input.GetAxis("Vertical1");
//    }
//    public void PlayerMovement()
//    {
//        Vector3 moveVector = transform.forward * horizontalMovement * moveSpeed*Time.deltaTime;
//        rb.MovePosition(rb.position + moveVector);
//        #region
//        // rb.MovePosition(transform.forward * horizontalMovement * moveSpeed);//Not work as when i am press button till then value of inout will be 1 ,
//        //After that when i will release button then vaslue =0 so it willl return back.
//        #endregion
//    }
//    public void PlayerRotation()
//    {
//        float rotation = verticalMovement * rotationSpeed*Time.deltaTime;
//        Quaternion rotationAngle = Quaternion.Euler(new Vector3(0f, rotation, 0f));
//        rb.MoveRotation(rb.rotation * rotationAngle);
//    }
//}
