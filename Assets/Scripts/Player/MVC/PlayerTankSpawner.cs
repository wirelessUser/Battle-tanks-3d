using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankSpawner : EventManager<PlayerTankSpawner>
{
    private PlayerHealth playerHealth;

    public PlayerTankView tankView;

    public PlayerTankView playerSpawned;
    public  override void Awake()
    {
        base.Awake();
        SpawnTank();
    
    }


    private void Start()
    {
        if (playerSpawned != null)
        {
            this.PlayerSpwnedEvent();
        }
    }

    public PlayerHealth ReturnPlayerHealth()
    {
       
        return playerHealth;
    }
    public void SpawnTank()
    {
        PlayerTankModel tankModel = new PlayerTankModel();
     
        PlayerTankController tankController = new PlayerTankController();

         playerSpawned = Instantiate(tankView, transform.parent);
       

    }

    public PlayerTankView ReturnView()
    {
        if (playerSpawned == null)
        {
            Debug.Log("Playerview Null..");
        }
        return playerSpawned;
    }
}
