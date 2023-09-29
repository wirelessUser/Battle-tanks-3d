using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTankView : MonoBehaviour, IGetComponentsInAwake,ITakeDamage
{
    public PlayerTankController tankController;

    private float horizontalInput;
    private float verticleInput;

    public PlayerScriptableObject dataSo;
    public CameraFollow mainCam;
    public Rigidbody rb;


    public Transform spawnPoint,  tankTransform;

    private Slider healthSlider;
    public float maxhealth;
    public float currentHealth;         //****DOUBT***
                                        // where to write that health code in the controlelr ? Means if can define
                                        // The maxHealth ,currenthEalth, damageAmount in the Model and from controlelr i can ask these valeus from model
                                        // And inside the Contolelr i can do the calculations for the Damage , But
                                        // View have a fucntion that will get called when the Bullet Will Hit The player and That view will call the ,
                                        // damage method of the Controller Right ?

                                         //****DOUBT***
                                        // we can't get components like Canvas Or other which are available in Hirarichy ,We can Only get prefab components in the Prpefabs Or
                                        // we can get get them only in runtime So at runtime it;s not good idea to get The components  ,So
                                        // we can get them in the Player service and from player service player can ask for  those componenst Right ?
                                        
    public float damageAmount=10;

    private void Awake()
    {
        GetComponenetsInAwake();
    }

    public void GetComponenetsInAwake()
    {
        healthSlider = PlayerTankSpawner.Instance.healthSlider;
        currentHealth = maxhealth;
        healthSlider.value = currentHealth;

        mainCam = PlayerTankSpawner.Instance.mainCam; ;
        mainCam.CameraSetup(this);
    }
    private void Update()
    {
        TakeInput();
       tankController.Move(horizontalInput); 
        tankController.Rotation(verticleInput);
        HealthBar();
        if (gameObject != null)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Shooting Playwr......");
            tankController.FireBulletLowDamage(spawnPoint);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
            tankController.FireBulletHighDamage(spawnPoint);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
            tankController.FireBulletOneShotDamage(spawnPoint);
            }
        }

    }

    public void SetController(PlayerTankController _tankController)     // Controller is Seeting those value So tankController of TankView can Be Initilaized.
    {
        tankController = _tankController; 
    }



    public void TakeInput()   
    {

        horizontalInput = Input.GetAxis("Vertical1");
        verticleInput = Input.GetAxis("Horizontal1");
    }

    public Rigidbody ReturnRb()    
    {
        return rb;        // return the rigidBody To the Player Controller...
        
    }



   public void HealthBar()
    {
        healthSlider.value =  currentHealth;
    }

    public void TakeDamage()
    {
        Debug.Log("Taking damage IDAMAGABLE and curretnHealth ="+currentHealth);
        currentHealth -= damageAmount;
        HealthBar();

    }
}
