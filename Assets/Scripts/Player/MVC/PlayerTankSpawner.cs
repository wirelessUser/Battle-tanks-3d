using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankSpawner : EventManager<PlayerTankSpawner>
{
    private PlayerHealth playerHealth;

    public PlayerTankView tankView;

    public PlayerTankView playerSpawned;

    PlayerTankModel tankModel;
    public int playerId;
    public  override void Awake()
    {
        base.Awake();
        SpawnTank();
        playerId = tankModel.id;
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
        tankModel = new PlayerTankModel();
     
        PlayerTankController tankController = new PlayerTankController();
       
         playerSpawned = Instantiate(tankView, transform.parent);
        tankController.PlayerTankControllerSetting(tankModel, tankView, playerSpawned);


    }

    public PlayerTankView ReturnView()
    {
       
        return playerSpawned;
    }
}
