using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyView : MonoBehaviour, IinitializeVariables, ITakeDamage
{
    private EnemyController enemyController;
    public GameObject[] dustTrailEffects;


    public Renderer[] myRenderer;

    public EnemyTankStates currentState;
    public EnemyTankStates patrollingState;
    public EnemyTankStates chasingState;
    public EnemyTankStates attackState;
    public int bulletHitCount;
    public Transform spawnPoint;
    public EnemyTankType enemyType;

    [SerializeField]
    private Slider healthSlider;
    public float maxhealth;
    public float currentHealth;
    // where to write that health code in the controlelr i need to define max health or in model ,if define in mdoel then accesebility issue will be there.
    // we can't get components like Canvas Or other which are available in iracy ,We can Only get prefab coponents in the rpefab Or
    // we can get get them only in runtime So at runtime you have denied to get them <So we can cget them in the Player service becuase
    // player serice is not prefab and we can get hirarcy compnent in it and from svcie we can get in isdie the Player Right ?
    public float damageAmount = 1;
    private void Awake()
    {

        InitializeVariables();



    }

    private void Update()
    {
        HealthBar();
    }

    private void Start()
    {
        ChangeEnemyState(currentState);

    }

    public void InitializeID(EnemyTankType _enemyType)
    {

        enemyType = _enemyType;
    }

    public void ChangeColor(Color _color)
    {
        foreach (Renderer item in myRenderer)
        {
            item.material.color = _color;
        }

    }

    public void InitializeVariables()
    {
        currentHealth = maxhealth;
        healthSlider.value = currentHealth;

        dustTrailEffects[0].SetActive(false);
        dustTrailEffects[1].SetActive(false);
    }
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }


    public void PlayParticleTrailEffect(bool isActive)
    {
        foreach (GameObject trail in dustTrailEffects)
        {
            trail.SetActive(isActive);
        }

    }



    public void ChangeEnemyState(EnemyTankStates newState)
    {
        if (currentState != null)
        {
            currentState.OnEnemyExitState();
        }

        currentState = newState;

        currentState.OnEnemyEnterState();
    }



    public void HealthBar()
    {
        healthSlider.value = currentHealth;
    }

    public void TakeDamage()
    {
        Debug.Log("Taking damage IDAMAGABLE and curretnHealth =" + currentHealth);
        currentHealth -= damageAmount;
        HealthBar();

    }



}

   