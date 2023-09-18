using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyView : MonoBehaviour,IinitializeVariables, IEnemyAchivementBulletHit
{
    public EnemyController enemyController;
    public GameObject[] dustTrailEffects;


    public Renderer[] myRenderer;

    public EnemyTankStates currentState;
    public EnemyTankStates patrollingState;
    public EnemyTankStates chasingState;
    public EnemyTankStates attackState;
    public int bulletHitCount;
    private void Awake()
    {
       //myRenderer = new Renderer[GetComponentsInChildren<Renderer>()];//
        InitializeVariables();
    }

    private void Start()
    {
        ChangeEnemyState(currentState);
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.GetComponent<BulletView>() && collision.gameObject.GetComponent<BulletView>().owner != this.gameObject)
    //    {
            
    //        EnemySpawner.Instance.EnemyBulletHitEvent()
    //    }
    //}


    public void AchivementPlayerBulletHit(int playerId)
    {
        bulletHitCount++;
       
        EnemySpawner.Instance.EnemyBulletHitEvent(playerId, bulletHitCount,GetComponent<EnemyModel>().id, GetComponent<EnemyModel>().enemyType);
    }
}
