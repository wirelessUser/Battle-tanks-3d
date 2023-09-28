using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="ScriptableObjects",menuName = "ScriptableObjects/playerTank")]
public class PlayerScriptableObject : ScriptableObject
{
    public string playerName;
    public PlayerTankType tankType;
    public GameEntityTypes gameEntityType;
    public int playerId;
    public int health;
    public float damage;
    public float movementSpeed;

    public int[] bulletPool = new int[3];

   
}
