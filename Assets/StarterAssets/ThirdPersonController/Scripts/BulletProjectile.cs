using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    [SerializeField] private Transform VfxHit;
    [SerializeField] private Transform VfxHitOther;
    private Rigidbody bulletRigidbody;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 40f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.GetComponent<BulletTarget>() != null)
        {
            // We hit a target
            Instantiate(VfxHit, transform.position, UnityEngine.Quaternion.identity);
        }

        else{
            // We hit something else
            Instantiate(VfxHitOther, transform.position, UnityEngine.Quaternion.identity);
        }
        Destroy(gameObject);
    }
}