using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel 
{
    public EnemyController enemyController;
    public EnemyDataScriptableObject so;
    public string tankName { get; private set; }

    public int maxHealth { get; private set; }

    public int currentHealth { get; private set; }

    public float damage { get; private set; }

    public float movementSpeed { get; private set; }

    public EnemyTankType enemyType;
    public int id { get;private set; }
    public void SetModel(EnemyDataScriptableObject data)
    {
        tankName = data.name;
        maxHealth = data.health;
        currentHealth = maxHealth;
        damage = data.damage;
        movementSpeed = data.movementSpeed;
        enemyType = data.tankType;
        id = data.id;
    }

    



    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

}
