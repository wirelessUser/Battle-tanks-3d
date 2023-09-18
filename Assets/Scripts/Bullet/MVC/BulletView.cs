using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour, IDestroyObject
{
    public BulletController controller;

    public BulletScriptableObject bulletSo;
    public Rigidbody rb;

    public GameObject owner;
    public int OwnerId;
    public int BulletHitCountEnemy;

    public void SetOwner(GameObject _owner,int _OwnerId)  //## i am checking collsion in the bulletView script (if any obejct implements ITakedamge() interface
                                             //then bullet will give damage to it ,But i want to make sure that Bullet dont give damage to it's Spanwer(Player Or Enemy).
                                             // So i am Setting the reference of the Spawner  here from the BulletSpawenr Script.
    {
        OwnerId = _OwnerId;
        owner = _owner;

    }
    private void Start()
    {
        StartCoroutine(Destroy(5));
    }
    public IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    public void SetBulletController(BulletController  _controller)
    {
        controller = _controller;
    }

 

    private void OnTriggerEnter(Collider collision)
    {
      
       if(collision.TryGetComponent<ITakeDamage>(out var damage)&& collision.gameObject != owner)  
        {
           
            damage.TakeDamage(10);
        }

       if(collision.TryGetComponent<IEnemyAchivementBulletHit>(out var achievement))
        {
            achievement.AchivementPlayerBulletHit(this.OwnerId);
        }
      // if(collision.gameObject.)
       
    }


   
}
