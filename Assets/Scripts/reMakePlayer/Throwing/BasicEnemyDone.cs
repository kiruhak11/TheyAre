using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyDone : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    private float rand;
    public GameObject bonusBox;
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0){
            bonus();
            reMakeChellenger.countKills += 1;
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    public void bonus(){
        rand = Random.Range(1.0f, 3.0f);
        
            GameObject projectile = Instantiate(bonusBox, transform.position, transform.rotation);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        
    }
}