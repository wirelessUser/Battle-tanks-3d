using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject explosionPrefab;
    [Range(10, 100)]
    public float maxHealth;
    public float currentHealth;

    public int bulletHit;

    private void Awake()
    {
        bulletHit = 0;
        currentHealth = maxHealth;
  
    }


    public void Death()
    {
        ExplosionEffect();
        StartCoroutine(EnemyDeath(this.gameObject));

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



    //public void TakeDamage( float damageAmount)
    //{
    //    bulletHit++;
    //    currentHealth -= damageAmount;
    //    if (currentHealth <= 0)
    //    {
    //        Death();

    //    }
       
    //}

  
}
