
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemySpawner : EventManager<EnemySpawner>
{
    public EnemyModel model;
    public List<AssetReferenceGameObject> enemyPrefabAddresable;
    public Transform[] spawnPoints;

    [SerializeField] public Dictionary<int, String> dict;
    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < enemyPrefabAddresable.Count; i++)
        {
            enemyPrefabAddresable[i].LoadAssetAsync().Completed += SpawneEnemy;
        }
    }

    private void Start()
    {
        // SpawneEnemy();
    }

    public void EnemySpoawn()
    {
    }

    public void SpawneEnemy(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject enemyPrefab = handle.Result;

         
                GameObject enemyInstance = Instantiate(enemyPrefab);

                enemyInstance.transform.position = spawnPoints[0].position;

                EnemyView enemyView = enemyInstance.GetComponent<EnemyView>();
                model = new EnemyModel();
                EnemyController controller = new EnemyController(enemyView, model);
                enemyView.InitializeID(model.enemyType);
           
        }
    }
}






#region Old COde.................

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
//public class EnemySpawner : EventManager<EnemySpawner>
//{

//    public EnemyModel model;
//    //......................................
//    public List<EnemyView> enemyPrefab;

//    public List<AssetReferenceGameObject> enemyPrefabAddresable;
//    public AssetReferenceGameObject enemyPrefabAddresableTwo;

//    //......................................
//    public Transform[] spawnPoints;
//    public Vector3 offset;
//    public EnemyAttckState enemyAttack;

//   public override void Awake()
//    {
//        base.Awake();
//        for (int i = 0; i < enemyPrefabAddresable.Count; i++)
//     {
//            enemyPrefabAddresable[i].LoadAssetAsync().Completed += SpawneEnemy;
//      }


//}




//    private void Start()
//    {
//       // SpawneEnemy();

//    }

//    public void EnemySpoawn()
//    {

//    }

//    public void SpawneEnemy(AsyncOperationHandle<GameObject> handle)
//    {
//        if (handle.Status == AsyncOperationStatus.Succeeded)
//        {
//            int i = 0;
//         //   for (; i < enemyPrefabAddresable.Count; i += 1)
//          //  {
//                Instantiate(handle.Result);
//                EnemyView enemyInst = Instantiate(handle.Result).GetComponent<EnemyView>();
//                //enemyInst.transform.position = spawnPoints[i].position;

//                 SetSpwnPOint( enemyInst);
//                model = new EnemyModel();
//                EnemyController controller = new EnemyController(enemyInst.GetComponent<EnemyView>(), model);

//                enemyInst.GetComponent<EnemyView>().InitializeID(model.enemyType);

//           // }
//        }


//    }


//    public void SetSpwnPOint(EnemyView enemyInst)
//    {
//        int i = 0;
//          for (; i < enemyPrefabAddresable.Count; i += 1)
//         {
//            enemyInst.transform.position = spawnPoints[i].position;
//           }
//    }



#endregion
