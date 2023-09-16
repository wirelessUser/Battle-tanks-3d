using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyTankStates : MonoBehaviour, IGetComponentsInAwake
{

    protected PlayerTankView playerTarget;
    protected EnemyView enemyview;

    [SerializeField]
    protected Color color;

    public Transform playerTransform;
    public EnemyStates enemyStates;
    protected NavMeshAgent navMeshAgent;
    public float attackDistance;
    public float chaseAfterAtackDistance = 2f;
    public EnemyView tankView;
    public virtual void Awake()
    {
        GetComponenetsInAwake();
        playerTarget = PlayerTankSpawner.Instance.ReturnView();  
        playerTransform = playerTarget.GetComponent<Transform>();
        PlayerTankSpawner.Instance.OnPlayerSpawned += InitializePlayer;
    }

    public void OnEnable()
    {
        Debug.Log("**OnEnable()***");   

    }

    public void OnDisable()
    {
        PlayerTankSpawner.Instance.OnPlayerSpawned -= InitializePlayer;
    }



    public  void InitializePlayer()   
    {
        Debug.Log("**InitiAlizePlayer***");
      playerTarget = PlayerTankSpawner.Instance.ReturnView();
        playerTransform = playerTarget.GetComponent<Transform>();
    }
    public virtual void OnEnemyEnterState() {
        this.enabled = true;
    }
    public virtual void OnEnemyExitState() {
        this.enabled = false;
    }

    public virtual void Update() { }



    public void GetComponenetsInAwake()
    {
        enemyview = GetComponent<EnemyView>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        tankView = GetComponent<EnemyView>();
    }


}
