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
    public BulletCategory bulletCategory;
    public BulletType bulletType;
    private string bulletName;
    public MeshRenderer mesh;
    public int selfDestructionTime;
    //public BulletScriptableObject BulletSo
    //{
    //    get { return bulletSo; }
    //    set { value = bulletSo; }
    //}
    public void SetOwner(GameObject _owner,int _OwnerId,BulletScriptableObject _bulletSo)  //## i am checking collsion in the bulletView script (if any obejct implements ITakedamge() interface                                           //then bullet will give damage to it ,But i want to make sure that Bullet dont give damage to it's Spanwer(Player Or Enemy)                                        // So i am Setting the reference of the Spawner  here from the BulletSpawenr Script.
    {
        bulletSo = _bulletSo;
        Debug.Log("SetOwner  Called.....");
        OwnerId = _OwnerId;
        owner = _owner;
       
        bulletCategory = bulletSo.bulletcategory;
        bulletName = bulletSo.BulleteName;

        bulletType = bulletSo.bulletType;
        bulletCategory = _bulletSo.bulletcategory;
        mesh.material.color = bulletSo.color;
        selfDestructionTime = bulletSo.selfDestructionTime;
    }

    


    private void Start()
    {
        StartCoroutine(Destroy(selfDestructionTime));
    }
    public IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);
       

        if (bulletType == BulletType.PlayerBullet)
        {
            DeactivateBulletSentBackToPlayerPool();
        }
        else
        {
            DeactivateBulletSentBackToEnemyPool();
        }
    }

    public void SetBulletController(BulletController  _controller)
    {
       
        controller = _controller;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject != owner)
        {
            if (collision.gameObject.GetComponent<EnemyView>() != null)
            {
                AchievementsManager.Instance.BulletHitCountEnemy++;
                AchivementCollison(collision);
            }


            if (bulletType == BulletType.PlayerBullet)
            {
                DeactivateBulletSentBackToPlayerPool();
            }
            else
            {
                DeactivateBulletSentBackToEnemyPool();
            }

        }

    }



    
    private void DeactivateBulletSentBackToEnemyPool()
    {
        BulletService.Instance.DestroyBullet(bulletSo.poolId - 1, this);
       
        this.gameObject.SetActive(false);
    }
    private void DeactivateBulletSentBackToPlayerPool()
    {
        BulletService.Instance.DestroyBullet(bulletSo.poolId-1, this);
        this.gameObject.SetActive(false);
    }


    private void AchivementCollison(Collider collision)
    {
        if (AchievementsManager.Instance.allBulletAchivementUnlocked == false)
        {

            AchievementsManager.Instance.CheckBulletAchivementUnlock(this.OwnerId, collision.gameObject.GetComponent<EnemyView>().enemyType);


            if (bulletType == BulletType.PlayerBullet)
            {
                DeactivateBulletSentBackToPlayerPool();
            }
            else
            {
                DeactivateBulletSentBackToEnemyPool();
            }
        }
    }

}


