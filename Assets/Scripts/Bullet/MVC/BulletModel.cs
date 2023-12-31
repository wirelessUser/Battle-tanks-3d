using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel 
{
    private  BulletType bulletType;

    private BulletScriptableObject data;

    private BulletController controller;


    public string bulleteName { get;  set; }
    public float speed { get; set; }
    public int damageCapacity { get; set; }


    public BulletModel(BulletScriptableObject data)
    {
        bulleteName = data.BulleteName;
        speed = data.speed;
        damageCapacity = data.damageCapacity;
    }

    public void SetBulletController(BulletController _controller)
    {
        Debug.Log("&&&&&Bullets Controler Set By View&&&&");
        controller = _controller;
    }
    
}
