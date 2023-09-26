using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttckState : EnemyTankStates, IinitializeVariables
{
    public float attackTimer;
    public float idleAttackTimeGap = 5;
   
   // public EnemyShootingBehaviour enemyShootingBehaviour;

   // private PlayerBulletSpanwer bulletSpawner;

    public Transform spawnPoint;

    public int enemyId;
    public EnemyTankType enemyTankType;
    public void SetIdAndTankType(int _enemyId, EnemyTankType _enemyTankType)
    {
        enemyId = _enemyId;
        enemyTankType = _enemyTankType;
    }

    public override void Awake()
    {
        base.Awake();
       
    }
    public override void OnEnemyEnterState()
    {
      
        base.OnEnemyEnterState();
        enemyview.ChangeColor(color);
        
    }

    public override void OnEnemyExitState()
    {
        base.OnEnemyExitState();
      
    }



    public  void   InitializeVariables()
    {
       
        attackTimer = idleAttackTimeGap;
        
    }
    public override void Update()
    {
        base.Update();
        Attack();
    }
    private void Attack()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.velocity = Vector3.zero;
        attackTimer += Time.deltaTime;
        if (attackTimer >= idleAttackTimeGap)
        {
            ShootAttack();
            attackTimer = 0;

        }
     
        if (Vector3.Distance(transform.position, playerTransform.position) >= attackDistance + 10)
        {
          
            enemyview.ChangeEnemyState(enemyview.chasingState );
        }

    }

    private void ShootAttack()
    {
        transform.LookAt(playerTransform);

        
       // EnemyBulletPooling.Instance.SpawnBullet(BulletEnum.EnemyBullet,enemyId,spawnPoint,this.gameObject);
        //PlayerBulletSpanwer.Instance.SpawnBullet(spawnPoint, BulletEnum.EnemyBullet, this.gameObject, enemyId);

    }




}
