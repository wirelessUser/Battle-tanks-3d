using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerTankSpawner : EventManager<PlayerTankSpawner>
{
    private PlayerHealth playerHealth;

    public PlayerTankView tankView;

    public PlayerTankView playerSpawned;

    PlayerTankModel tankModel;
    public CameraFollow mainCam;

    public Slider healthSlider;
    public int playerId;
    public  override void Awake()
    {
        Debug.Log("Player Awake called...."); 
        base.Awake();
        SpawnTank();
        playerId = tankModel.id;
    }
  
   
    private void Start()
    {
        Debug.Log("Player Start called....");
        if (playerSpawned != null)
        {
            this.PlayerSpwnedEvent();
        }
    }


    private void OnEnable()
    {
        Debug.Log("Player OnEnable called....");
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
