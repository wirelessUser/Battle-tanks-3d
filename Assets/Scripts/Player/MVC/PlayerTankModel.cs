using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankModel 
{
    public PlayerTankType TankType { get; private set ; }
    public PlayerTankController tankController;
    public string name { get; private set; }
    public int health { get; private set; }

    public float currentHealth;
    public float damage { get; private set; }

    public float movementSpeed { get; private set ; }

    public int id { get; private set; }
    public PlayerScriptableObject playerSo;  
    public void SetController(PlayerTankController _tankController)
    {
        tankController = _tankController;
    }
    public void SetPlayerTankModel(PlayerScriptableObject data)
    {
        playerSo = data;
         name = data.name;
        
        health = data.health;
        currentHealth = health;
        damage = data.damage;
        movementSpeed = data.movementSpeed;
        id = data.playerId;


    }

}
