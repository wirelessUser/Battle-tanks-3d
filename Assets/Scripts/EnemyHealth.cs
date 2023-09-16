using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,ITakeDamage
{
    public GameObject explosionPrefab;
    [Range(10, 100)]
    public float maxHealth;
    public float currentHealth;

    

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Death()
    {

        ExplosionEffect();
        StartCoroutine(EnemyDeath(this.gameObject));


    }

    private void OnEnable()
    {
      
           
            EventManager<PlayerTankSpawner>.Instance.onPlayerDeath += Death;
        
    }


    private void OnDisable()
    {
      
           
      PlayerTankSpawner.Instance.onPlayerDeath -= Death;
        
    }


    public void ExplosionEffect()
    {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = this.gameObject.transform.localPosition;
    }
    private IEnumerator EnemyDeath(GameObject gameObject)
    {

        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);

    }



    public void TakeDamage( float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Death();

        }
       
    }
}
