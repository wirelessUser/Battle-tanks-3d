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
    public PlayerBullet bulletType;
  //  public PlayerBullet bulletTypePlayer;
    public void SetOwner(GameObject _owner,int _OwnerId, PlayerBullet _bulletType)  //## i am checking collsion in the bulletView script (if any obejct implements ITakedamge() interface
                                             //then bullet will give damage to it ,But i want to make sure that Bullet dont give damage to it's Spanwer(Player Or Enemy).
                                             // So i am Setting the reference of the Spawner  here from the BulletSpawenr Script.
    {
        OwnerId = _OwnerId;
        owner = _owner;
        bulletType = _bulletType;
    }

    private void OnEnable()
    {
        // AchievementsManager.Instance.EnemeyBulletHitAchivementUnlock += CheckBulletAchivementUnlock; 

    }


    private void OnDisable()
    {
       // AchievementsManager.Instance.EnemeyBulletHitAchivementUnlock -= CheckBulletAchivementUnlock;

    }
    private void Start()
    {
        StartCoroutine(Destroy(5));
    }
    public IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        PlayerBulletPoolingScript.Instance.DestroyBullet(bulletType, this);
    }

    public void SetBulletController(BulletController  _controller)
    {
        Debug.Log("&&&&&Bullets Controler Set By View&&&&");
        controller = _controller;
    }


   
    private void OnCollisionEnter(Collision collision)
    {
       
       
        if (collision.gameObject != owner)
        {
            if (collision.gameObject.GetComponent<EnemyView>() != null)
            {
                AchievementsManager.Instance.BulletHitCountEnemy++;
                AchivementCollison(collision);
            }
            DeactivateBulletSentBackToPool();
        }



    }

    private void DeactivateBulletSentBackToPool()
    {
        PlayerBulletPoolingScript.Instance.DestroyBullet(bulletType, this);
        this.gameObject.SetActive(false);
    }


    private void AchivementCollison(Collision collision)
    {
        if (AchievementsManager.Instance.allBulletAchivementUnlocked == false)
        {

            AchievementsManager.Instance.CheckBulletAchivementUnlock(this.OwnerId, collision.gameObject.GetComponent<EnemyView>().enemyType);

            DeactivateBulletSentBackToPool();
        }
    }

}


