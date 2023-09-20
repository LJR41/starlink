using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    [SerializeField] private Transform VfxHit;
    [SerializeField] private Transform VfxHitOther;
    public float damage = 20;
    private Rigidbody bulletRigidbody;
    public Enemy _enemy;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 40f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Enemy") 
        {
            //We hit an enemy
            Instantiate(VfxHit, transform.position, UnityEngine.Quaternion.identity);
            
            _enemy.TakeDamage(damage);
        }

        else{
            // We hit something else
            Instantiate(VfxHitOther, transform.position, UnityEngine.Quaternion.identity);
        }
        Destroy(gameObject);
    }
}