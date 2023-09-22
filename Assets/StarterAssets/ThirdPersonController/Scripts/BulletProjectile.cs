using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BulletProjectile : MonoBehaviour {

    [SerializeField] Transform VfxHit;
    [SerializeField] Transform VfxHitOther;
    public float damage = 5;
    private Rigidbody bulletRigidbody;
    

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        float speed = 120f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision otherCollision)
    {
        
        if (otherCollision.gameObject.TryGetComponent<SmallEnemy>(out SmallEnemy smallEnemy)) 
        {
            //We hit an enemy
            smallEnemy.TakeDamage(damage);
            print("Current Enemy health :"+smallEnemy._Health);
            Instantiate(VfxHit, transform.position, UnityEngine.Quaternion.identity);
            //UnityEngine.Debug.Log("Hit");
        }

        else{
            // We hit something else
            Instantiate(VfxHitOther, transform.position, UnityEngine.Quaternion.identity);
        }

        if(otherCollision.gameObject.TryGetComponent<MediumEnemy>(out MediumEnemy mediumEnemy))
        {
            mediumEnemy.TakeDamage(damage);
            print("Current Enemy health :" + mediumEnemy._Health);
            Instantiate(VfxHit, transform.position, UnityEngine.Quaternion.identity);
        }
        else
        {
            // We hit something else
            Instantiate(VfxHitOther, transform.position, UnityEngine.Quaternion.identity);
        }

        if (otherCollision.gameObject.TryGetComponent<BossEnemy>(out BossEnemy bossEnemy))
        {
            bossEnemy.TakeDamage(damage);
            print("Current Enemy health :" + bossEnemy._Health);
            Instantiate(VfxHit, transform.position, UnityEngine.Quaternion.identity);
        }
        else
        {
            // We hit something else
            Instantiate(VfxHitOther, transform.position, UnityEngine.Quaternion.identity);
        }
        Destroy(gameObject);
    }
}