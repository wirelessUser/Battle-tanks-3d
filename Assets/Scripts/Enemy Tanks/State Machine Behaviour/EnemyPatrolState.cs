using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyPatrolState : EnemyTankStates, IGetComponentsInAwake, IinitializeVariables
{

    public float PatrolMinRadius = 20;
    public float patrolMaxradius = 60;
    public float patrolTimer;
    public float idlePatrolTime = 20f;

    public float chasingDistance;

    public float currentChaseDistance;
    public float patrolSpeed;
 
    private Transform cubeLocator;
    

    public override void Awake()
    {
        base.Awake();
       
    }
    public override void OnEnemyEnterState()
    {
        base.OnEnemyEnterState();
        InitializeVariables();
        
        enemyview.ChangeColor(color);
        

    }
  

    public override void OnEnemyExitState()
    {
        base.OnEnemyExitState();

    }

    public override void Update()
    {
        base.Update();

        Patrol();
    }

    protected void SetNewDestinationPointForEnemy()
    {

      
        float randomRadius = Random.Range(PatrolMinRadius, patrolMaxradius);
        
        Vector3 dir = Random.insideUnitSphere;
     
        dir *= (randomRadius);
       
        NavMeshHit hit;

        NavMesh.SamplePosition(dir, out hit, randomRadius, NavMesh.AllAreas);
      
        navMeshAgent.SetDestination(hit.position);


    }
    public  void InitializeVariables()
    {
        patrolTimer = idlePatrolTime;
        currentChaseDistance = chasingDistance;
  
    }


    protected void ChekDistanceToChaseOrAttack(float distance, EnemyStates _enemyState)
    {
        if (Vector3.Distance(transform.position, playerTransform.position) <= distance)
        {
            enemyview.ChangeEnemyState(enemyview.chasingState);
        }
    }

    private void Patrol()
    {
        ChekDistanceToChaseOrAttack(chasingDistance, EnemyStates.Chase);
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = patrolSpeed;

        patrolTimer += Time.deltaTime;

        if (patrolTimer > idlePatrolTime)
        {
            SetNewDestinationPointForEnemy();
            patrolTimer = 0;
        }


        if (navMeshAgent.velocity.sqrMagnitude > 0.5)
        {
            tankView.PlayParticleTrailEffect(true);
        }
        else
        {
            tankView.PlayParticleTrailEffect(false);
        }

        //  Debug.Log($"From Patrol** Distace B/W = {Vector3.Distance(transform.position, playerTarget.position)}");
    }
}
