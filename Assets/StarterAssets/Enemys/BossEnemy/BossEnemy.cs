using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{


    [SerializeField] bool rangeAttackState;

    [Header("------------------Ranged Attack Variables-------------------")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float projectileForce = 1000f;
    [SerializeField] float rangedAttackCooldown = 1f;
    private float lastRangedAttackTime;

   new private void Awake()
    {
        base.Awake(); 
    }

    new private void Update()
    {
        base.Update(); 

        if (CanPerformRangedAttack())
        {
            PerformRangedAttack();
        }
    }

    private bool CanPerformRangedAttack()
    {
        return _attackState && Time.time - lastRangedAttackTime >= rangedAttackCooldown;
    }

    private void PerformRangedAttack()
    {
        if (projectilePrefab == null || projectileSpawnPoint == null)
        {
            Debug.LogError("Projectile prefab or spawn point not set in the BossEnemy script!");
            return;
        }

        // Instantiate the projectile.
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        // Calculate the direction towards the player.
        Vector3 direction = (playerTransform.position - projectileSpawnPoint.position).normalized;

        // Apply force to the projectile.
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * projectileForce;
        }

        lastRangedAttackTime = Time.time;
    }

    //private void OnTriggerEnter(Collider otherCollider)
    //{
    //    if(otherCollider.name == "player")
    //    {

    //    }
    //}
}
